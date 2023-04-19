using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IFlightBookingRepository : IRepository<Tuple<int,int>,FlightBooking>
{
}

