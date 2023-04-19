using Agency.service;
using log4net.Config;
using Networking;
using ServerTemplate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class StartServer
    {

        static void Main(string[] args)
        {
            //ApplicationConfiguration.Initialize();
            XmlConfigurator.Configure();
            IDictionary<string, string> props = new SortedList<string, string>();
            props.Add("ConnectionString", GetConnectionStringByName("agency"));

            IChatService serviceImpl = new AgencyService(new AgentDBRepository(props), new ClientDBRepository(props),
                new FlightDBRepository(props), new FlightBookingDBRepository(props));

            SerialChatServer server = new SerialChatServer("127.0.0.1", 55556, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();

        }
        private static string GetConnectionStringByName(string agency)
        {
            string returnValue = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[agency];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            return returnValue;
        }
    }

    public class SerialChatServer : ConcurrentServer
    {
        private IChatService server;
        private ChatClientObjectWorker worker;
        public SerialChatServer(string host, int port, IChatService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ChatClientObjectWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
