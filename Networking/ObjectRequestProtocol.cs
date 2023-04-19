using System;
namespace Networking
{
	public interface Request 
	{
	}


	[Serializable]
	public class LoginRequest : Request
	{
        private Agent user;

        public LoginRequest(Agent user)
        {
            this.user = user;
        }

        public Agent getUser()
        {
            return user;
        }
    }

	[Serializable]
	public class LogoutRequest : Request
	{
        private Agent user;

        public LogoutRequest(Agent user)
        {
            this.user = user;
        }

        public Agent getUser()
        {
            return user;
        }
    }

	[Serializable]
	public class GetFlightsRequest : Request
	{
        private string destination;
        private DateTime date;

        public GetFlightsRequest(string destination, DateTime date)
        {
            this.destination = destination;
            this.date = date;
        }

        public string getDestination()
        {
            return destination;
        }

        public DateTime getDate()
        {
            return date;
        }
    }

	[Serializable]
	public class GetAllAvailableFlightsRequest : Request
	{
	}

    [Serializable]
    public class AddBookingRequest : Request
    {
        private Flight flight;
        private Client client;

        public AddBookingRequest(Flight flight, Client client)
        {
            this.flight = flight;
            this.client = client;
        }

        public Flight getFlight()
        {
            return flight;
        }

        public Client getClient()
        {
            return client;
        }
    }
}