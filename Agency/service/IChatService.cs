using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.service
{
    public interface IChatService
    {
        void login(Agent agent, IChatObserver client);
        void logout(Agent agent, IChatObserver client);

        void finishBooking(Client client, Flight flight);

        List<Flight> getFilteredFlights(string destination, DateTime date);
        List<Flight> getAllAvailableFlights();
    }
}
