using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Agency.service;

namespace Networking
{

	public class ChatClientObjectWorker :  IChatObserver //, Runnable
	{
		private IChatService server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public ChatClientObjectWorker(IChatService server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				connected=true;
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while(connected)
			{
				try
				{
                    object request = formatter.Deserialize(stream);
					object response =handleRequest((Request)request);
					if (response!=null)
					{
					   sendResponse((Response) response);
					}
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
				
				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error "+e);
			}
		}	

		private Response handleRequest(Request request)
		{
			Response response =null;
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq =(LoginRequest)request;
                Agent agent = logReq.getUser();
                try
                {
                    lock (server)
                    {
                        server.login(agent, this);
                    }
					return new OkResponse();
				}
				catch (ChatException e)
				{
					connected=false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request");
				LogoutRequest logReq =(LogoutRequest)request;
                Agent agent = logReq.getUser();
                try
				{
                    lock (server)
                    {

                        server.logout(agent, this);
                    }
					connected=false;
					return new OkResponse();

				}
				catch (ChatException e)
				{
				   return new ErrorResponse(e.Message);
				}
			}
			if (request is AddBookingRequest)
			{
				Console.WriteLine("AddBookingRequest ...");
                AddBookingRequest senReq = (AddBookingRequest)request;
                try
				{
                    lock (server)
                    {
                        server.finishBooking(senReq.getClient(), senReq.getFlight());
                    }
                        return new OkResponse();
				}
				catch (ChatException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			if (request is GetFlightsRequest)
			{
				Console.WriteLine("GetFlightsRequest Request ...");
                GetFlightsRequest getReq = (GetFlightsRequest)request;
                DateTime date = getReq.getDate();
                String destination = getReq.getDestination();
                try
				{
					List<Flight> flights = new List<Flight>();
                    lock (server)
                    {
                       flights  = server.getFilteredFlights(destination, date);
                    }
					
					return new GetFlightsResponse(flights);
				}
				catch (ChatException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

            if (request is GetAllAvailableFlightsRequest)
            {
                Console.WriteLine("GetAllAvailableFlightsRequest Request ...");
                GetAllAvailableFlightsRequest getReq = (GetAllAvailableFlightsRequest)request;
                try
                {
                    List<Flight> flights = new List<Flight>();
                    lock (server)
                    {
                        flights = server.getAllAvailableFlights();
                    }

                    return new GetAllAvailableFlightsResponse(flights);
                }
                catch (ChatException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            return response;
		}

	private void sendResponse(Response response)
		{
			Console.WriteLine("sending response "+response);
			lock (stream)
			{
				formatter.Serialize(stream, response);
				stream.Flush();
			}

		}

    public virtual void updateFlights(Flight flight)
    {
            Console.WriteLine("Flight modified  " + flight);
            try
            {
                sendResponse(new FinishBookingResponse(flight));
            }
            catch (Exception e)
            {
                throw new ChatException("Sending error: " + e);
            }
    }

}

}