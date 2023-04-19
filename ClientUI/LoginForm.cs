using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agency.service;
using ClientUI;
using Microsoft.VisualBasic.ApplicationServices;
using SwimmingContest.repository;

namespace Agency
{
    public partial class LoginForm : Form
    {
        private ChatClientCtrl ctrl;
        public LoginForm(ChatClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FlightBookingDBRepository repo = new FlightBookingDBRepository(props);

            //FlightDBRepository repo = new FlightDBRepository(props);
            
            //ClientDBRepository repo = new ClientDBRepository(props);
            /*
            foreach (var f in repo.GetAll())
            {
                Console.WriteLine(f.ToString());
            }
            */
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string agency = agencyTextBox.Text;
            string password = passwordTextBox.Text;
            if (username != "" && agency != "" && password != "")
            {
                
                try
                {
                    ctrl.login(agency,username,password);
                    DestinationsForm destForm = new DestinationsForm(ctrl);
                    destForm.Text = "Window for " + username;
                    destForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}