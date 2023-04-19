using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Agency.service;
using SwimmingContest.repository;

namespace Networking
{
	
	public class ChatServerProxy : IChatService
	{
		private string host;
		private int port;

		private IChatObserver client;

		private NetworkStream stream;
		
        private IFormatter formatter;
		private TcpClient connection;

		private Queue<Response> responses;
		private volatile bool finished;
        private EventWaitHandle _waitHandle;
		public ChatServerProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
			responses=new Queue<Response>();
		}

        public virtual void login(Agent agent, IChatObserver client)
        {
			initializeConnection();
            
            sendRequest(new LoginRequest(agent));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client = client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new ChatException(err.Message);
            }
        }

        public virtual void logout(Agent agent, IChatObserver client)
        {
            sendRequest(new LogoutRequest(agent));
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ChatException(err.Message);
            }
        }

        public virtual void finishBooking(Client client, Flight flight)
        {
            sendRequest(new AddBookingRequest(flight, client));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ChatException(err.Message);
            }
        }

        public virtual List<Flight> getFilteredFlights(string destination, DateTime date)
        {
            sendRequest(new GetFlightsRequest(destination, date));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ChatException(err.Message);
            }
            GetFlightsResponse resp = (GetFlightsResponse)response;
            List<Flight> flights = resp.getFlightList();

            return flights;
        }

        public virtual List<Flight> getAllAvailableFlights()
        {
            sendRequest(new GetAllAvailableFlightsRequest());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ChatException(err.Message);
            }
            GetAllAvailableFlightsResponse resp = (GetAllAvailableFlightsResponse)response;
            List<Flight> flights = resp.getFlights();

            return flights;
        }

		private void closeConnection()
		{
			finished=true;
			try
			{
				stream.Close();
			
				connection.Close();
                _waitHandle.Close();
				client=null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
                formatter.Serialize(stream, request);
                stream.Flush();
			}
			catch (Exception e)
			{
				throw new ChatException("Error sending object "+e);
			}

		}

		private Response readResponse()
		{
			Response response =null;
			try
			{
                _waitHandle.WaitOne();
				lock (responses)
				{
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
				}
				

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		private void initializeConnection()
		{
			 try
			 {
				connection=new TcpClient(host,port);
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				finished=false;
                _waitHandle = new AutoResetEvent(false);
				startReader();
			}
			catch (Exception e)
			{
				Console.WriteLine("aloooooo");
                Console.WriteLine(e.StackTrace);
			}
		}
		private void startReader()
		{
			Thread tw =new Thread(run);
			tw.Start();
		}


		private void handleUpdate(UpdateResponse update)
		{
			if (update is FinishBookingResponse)
			{

                FinishBookingResponse upd = (FinishBookingResponse)update;
				Flight flight = upd.getFlight();
                Console.WriteLine("FinishBookingResponse " + flight);
				try
				{
					client.updateFlights(flight);
				}
				catch (ChatException e)
				{
                    Console.WriteLine(e.StackTrace); 
				}
			}
		}
		public virtual void run()
			{
				while(!finished)
				{
					try
					{
                        object response = formatter.Deserialize(stream);
						Console.WriteLine("response received "+response);
						if (response is UpdateResponse)
						{
							 handleUpdate((UpdateResponse)response);
						}
						else
						{
							
							lock (responses)
							{
                                					
								 
                                responses.Enqueue((Response)response);
                               
							}
                            _waitHandle.Set();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Reading error "+e);
					}
					
				}
			}

        
        //}
    }

}