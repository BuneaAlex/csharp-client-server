using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IClientRepository : IRepository<int,Client>
{
    List<Client> findClientsByNoOfSeatsReserved(int noOfSeats);
}

