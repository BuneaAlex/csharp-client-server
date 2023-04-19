using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.service
{
    public interface IChatObserver
    {
        void updateFlights(Flight flight);
    }
}
