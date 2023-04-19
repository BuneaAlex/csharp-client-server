using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IAgentRepository : IRepository<int,Agent>
{
    Agent FindAgentByLoginInformation(string agencyName, string userName, string password);
}

