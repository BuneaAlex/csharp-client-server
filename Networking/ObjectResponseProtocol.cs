using System;
namespace Networking
{

	public interface Response 
	{
	}

	[Serializable]
	public class OkResponse : Response
	{
		
	}

    [Serializable]
	public class ErrorResponse : Response
	{
		private string message;

		public ErrorResponse(string message)
		{
			this.message = message;
		}

		public virtual string Message
		{
			get
			{
				return message;
			}
		}
	}

	[Serializable]
	public class GetFlightsResponse : Response
	{
        List<Flight> flightList;

        public GetFlightsResponse(List<Flight> flightList)
        {
            this.flightList = flightList;
        }

        public List<Flight> getFlightList()
        {
            return flightList;
        }
    }
	public interface UpdateResponse : Response
	{
	}

	[Serializable] 
	public class GetAllAvailableFlightsResponse : Response
	{
        List<Flight> flights;

        public GetAllAvailableFlightsResponse(List<Flight> flights)
        {
            this.flights = flights;
        }

        public List<Flight> getFlights()
        {
            return flights;
        }
    }

	[Serializable]
	public class AddBookingResponse : Response
	{
	}


	[Serializable]
	public class FinishBookingResponse : UpdateResponse
	{
        private Flight flight;

        public FinishBookingResponse(Flight flight)
        {
            this.flight = flight;
        }

        public Flight getFlight()
        {
            return flight;
        }
    }

}