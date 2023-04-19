using Agency;
using Agency.service;
using log4net.Config;
using Networking;
using System.Configuration;

namespace ClientUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            XmlConfigurator.Configure();
            IDictionary<string, string> props = new SortedList<string, string>();
            props.Add("ConnectionString", GetConnectionStringByName("agency"));
            /*
            ClientDBRepository repo = new ClientDBRepository(props);

            foreach (var f in repo.GetAll())
            {
                Console.WriteLine(f.ToString());
            }
            */
            //FlightDBRepository repo = new FlightDBRepository(props);
            //repo.Save(new Flight(0, "Liverpool", DateTime.Now, "airport2", 100));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AgentDBRepository repo = new AgentDBRepository(props);
            
            foreach (var f in repo.GetAll())
            {
                Console.WriteLine(f.ToString());
            }

            IChatService server = new ChatServerProxy("127.0.0.1", 55556);
            ChatClientCtrl ctrl = new ChatClientCtrl(server);
            LoginForm frm = new LoginForm(ctrl);
            Application.Run(frm);
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

}