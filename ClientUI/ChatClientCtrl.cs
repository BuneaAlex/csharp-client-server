using Agency.service;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClientUI
{
    public class ChatClientCtrl : IChatObserver
    {
        
        public event EventHandler<ChatUserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IChatService server;
        private Agent currentUser;
        public ChatClientCtrl(IChatService server)
        {
            this.server = server;
            currentUser = null;
        }

        public void login(string agency,string username,string password)
            {
                int id = Int32.Parse(username[username.Length - 1].ToString());
                Agent agent = new Agent(id, agency, username, password);
            
                server.login(agent, this);
                Console.WriteLine("Login succeeded ....");
                currentUser = agent;
                Console.WriteLine("Current user {0}", agent);
            }

        public void updateFlights(Flight flight)
        {
            ChatUserEventArgs userArgs = new ChatUserEventArgs(ChatUserEvent.UpdateFlights, flight);
            Console.WriteLine("Flights updated");
            OnUserEvent(userArgs);
        }

        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.logout(currentUser, this);
            currentUser = null;
        }

        protected virtual void OnUserEvent(ChatUserEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }

        public List<Flight> getFilteredFlights(string destination, DateTime date)
        {
            return server.getFilteredFlights(destination, date);
        }

        public Flight findFlightById(int id)
        {
            foreach(Flight f in server.getAllAvailableFlights())
            {
                if(f.getID() == id) 
                    return f;
            }
            return null;
        }

        public List<Flight> getAllAvailableFlights()
        {
            return server.getAllAvailableFlights();
        }

        public void finishBooking(Client client, Flight flight)
        {
            updateFlights(flight);
            server.finishBooking(client, flight);
        }

    }
}
