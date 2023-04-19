using log4net.Config;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;

namespace Agency
{
    internal class Program
    {
        static void Main()
        {
            //Debug.WriteLine("Hello");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            XmlConfigurator.Configure();
            IDictionary<string, string> props = new SortedList<string, string>();
            props.Add("ConnectionString", GetConnectionStringByName("agency"));

            AgentDBRepository repo = new AgentDBRepository(props);
            //repo.Save(new Agent(0, "agency2", "user2", "1234"));
            foreach (var f in repo.GetAll())
            {
                Console.WriteLine(f.ToString());
            }
            

            //LoginForm frm = new LoginForm(props);
            //Application.Run(frm);
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