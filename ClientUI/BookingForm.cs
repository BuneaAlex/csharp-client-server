using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Agency
{
    public partial class BookingForm : Form
    {
        private AgencyService service;
        private Agent agent;
        private Flight flight;
        IDictionary<string, string> props;
        public BookingForm(Flight flight,Agent agent,IDictionary<string, string> props)
        {
            InitializeComponent();
            this.props = props;
            this.agent = agent;
            this.flight= flight;
            service = new AgencyService(new AgentDBRepository(props), new ClientDBRepository(props),
                new FlightDBRepository(props), new FlightBookingDBRepository(props));
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            string infoFlight = flight.ToString();
            labelInfo.Text = infoFlight;
        }

      

        

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string clientName = clientTextBox.Text;
            string tourists = touristsTextBox.Text;
            string address = addressTextBox.Text;
            string noSeats = noOfSeatsTextBox.Text;

            if (clientName != "" && tourists != "" && address != "" && noSeats != "")
            {
                int numberOfSeats = Int32.Parse(noSeats);
                if (numberOfSeats > flight.NoOfSeatsLeft)
                {
                    MessageBox.Show("Not enough seats left!");                   
                }
                else
                {
                    Client clientToBeAdded = new Client(0,clientName, tourists, address, numberOfSeats);
                    flight.NoOfSeatsLeft = flight.NoOfSeatsLeft - numberOfSeats;

                    Client rezClient = service.addClient(clientToBeAdded);
                    service.updateNoSeatsLeftFlight(flight);
                    service.addBooking(rezClient, flight);

                    MessageBox.Show(rezClient.ToString() + " " + 
                        service.findFlightById(flight.getID()).ToString());

                    
                    /*
                    DestinationsForm f = new DestinationsForm(agent, props);
                    this.Hide();
                    f.Show();
                    */
                }


            }
           
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            /*
            DestinationsForm f = new DestinationsForm(agent,props);
            this.Hide();
            f.Show();
            */
        }

        private void BookingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void labelClient_Click(object sender, EventArgs e)
        {

        }

        private void clientTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void labelTourists_Click(object sender, EventArgs e)
        {

        }

        private void touristsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelAddress_Click(object sender, EventArgs e)
        {

        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void noOfSeatsTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
