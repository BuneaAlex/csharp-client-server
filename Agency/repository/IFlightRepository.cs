using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IFlightRepository : IRepository<int,Flight>
{
    List<Flight> FindFlightByDestinationAndDatetime(string destination, DateTime date);
    List<Flight> FindAvailableFlights();
}

