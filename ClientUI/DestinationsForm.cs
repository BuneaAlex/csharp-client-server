using Agency.service;
using ClientUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agency
{
    public partial class DestinationsForm : Form
    {
        private readonly ChatClientCtrl ctrl;
        private Flight selectedFlight = null;
        private List<Flight> flights;
        BindingSource source;
        public DestinationsForm(ChatClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            flights= new List<Flight>();
            source= new BindingSource();
            ctrl.updateEvent += userUpdate;
        }

        private void DestinationsForm_Load(object sender, EventArgs e)
        {
            //destinationsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //filteredDestinationsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            flights = ctrl.getAllAvailableFlights();
            source.DataSource = flights;
            destinationsDataGridView.DataSource = source;
            /*
            flights = ctrl.getAllAvailableFlights();
            var source = new BindingSource();
            source.DataSource = flights;
            destinationsDataGridView.DataSource = source;
            */
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            int indexRow = filteredDestinationsDataGridView.SelectedRows[0].Index;
            if(indexRow != -1)
            {
                DataGridViewRow selectedRow = filteredDestinationsDataGridView.Rows[indexRow];
                FlightDTO flightDTO = (FlightDTO)selectedRow.DataBoundItem;
                selectedFlight = ctrl.findFlightById(flightDTO.getID());
                string infoFlight = selectedFlight.ToString();
                labelInfo.Text = infoFlight;
                /*
                BookingForm f = new BookingForm(flight,agent, props);
                this.Hide();
                f.Show();
                */
            }
            
        }

        private void DestinationsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Window closing " + e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ctrl.logout();
                ctrl.updateEvent -= userUpdate;
                Application.Exit();
            }
        }

        public void userUpdate(object sender, ChatUserEventArgs e)
        {
            if (e.UserEventType == ChatUserEvent.UpdateFlights)
            {
                Console.WriteLine(e.Data);
                Flight flight = (Flight)e.Data;
            
                Console.WriteLine("Update la table " + flight);
                destinationsDataGridView.BeginInvoke(new UpdateTableCallback(this.updateTable), new Object[] { destinationsDataGridView, flight });
                   
            }
        }

        private void updateTable(DataGridView table,Flight flight)
        {
            filteredDestinationsDataGridView.Rows.Clear();
            table.DataSource = null;
            foreach(Flight f in flights)
            {
                if(f.getID() == flight.getID())
                {
                    f.NoOfSeatsLeft = flight.NoOfSeatsLeft;
                }
            }
            table.DataSource = source;
        }

        public delegate void UpdateTableCallback(DataGridView table, Flight flight);

        private void logOutButton_Click(object sender, EventArgs e)
        {
            ctrl.logout();
            ctrl.updateEvent -= userUpdate;
            Application.Exit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string destination = destinationTextBox.Text;
            DateTime date = dateTimePicker.Value;

            if(destination != "")
            {
                List<Flight> flights = ctrl.getFilteredFlights(destination, date);
                List<FlightDTO> flightDTOs = new List<FlightDTO>();
                var source = new BindingSource();
                foreach(var f in flights)
                {
                    FlightDTO fdto = new FlightDTO(f.getID(), f.Date, f.NoOfSeatsLeft);
                    flightDTOs.Add(fdto);
                }
                source.DataSource = flightDTOs;
                filteredDestinationsDataGridView.DataSource = source;
            }
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
                if (numberOfSeats > selectedFlight.NoOfSeatsLeft)
                {
                    MessageBox.Show("Not enough seats left!");
                }
                else
                {
                    Client clientToBeAdded = new Client(0, clientName, tourists, address, numberOfSeats);
                    selectedFlight.NoOfSeatsLeft = selectedFlight.NoOfSeatsLeft - numberOfSeats;

                    ctrl.finishBooking(clientToBeAdded, selectedFlight);

                    MessageBox.Show(clientToBeAdded.ToString() + " " +
                        selectedFlight.ToString());

                }


            }
        }
    }
}
