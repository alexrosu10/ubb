using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferenceManager.ConferenceManager.GUI
{
    public partial class CreateChairAccount : Form
    {
        private Controller.Controller controller = null;

        public CreateChairAccount(Controller.Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            controller.repository.ListenerSet.Load();

        }

        private void CreateChairAccount_Load(object sender, EventArgs e)
        {
            
        }
        
        private Listener getUser(string name, string password)
        {
            
            var info = controller.repository.ListenerSet.ToList();
            foreach (var user in info)
            {

                if (user.Username == name && user.Password == password)
                    return user;
            }
            return null;
        }

        private void CreateAccountButton_MouseClick(object sender, MouseEventArgs e)
        {
            /**
             * Validate account information, prompt user to retry if wrong, else go to createConferenceWindow
             */
            if (this.UsernameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Username can't be empty");
                return;
            }

            foreach (var user in controller.repository.ListenerSet)
            {
                if (user.Username.Equals(this.UsernameTextBox.Text))
                {
                    MessageBox.Show("Username is taken!");
                    return;
                }
            }

            if (!this.PasswordTextBox.Text.Equals(this.RetypeTextBox.Text))
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (this.FirstNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("First name is required!");
                return;
            }

            if (this.LastNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Last name is required!");
                return;
            }

            if (this.AffiliationTextBox.Text.Equals(""))
            {
                MessageBox.Show("Affiliation is required!");
                return;
            }

            if (this.EmailTextBox.Text.Equals(""))
            {
                MessageBox.Show("Email is required!");
                return;
            }

            if (this.WebPageTextBox.Text.Equals(""))
            {
                MessageBox.Show("Web Page is required!");
                return;
            }

            ConferenceChair newChair = new ConferenceChair
            {
                Username = this.UsernameTextBox.Text,
                Password = this.PasswordTextBox.Text,
                Name = this.FirstNameTextBox.Text + " " + this.LastNameTextBox.Text,
                Affiliation = this.AffiliationTextBox.Text,
                Email = this.EmailTextBox.Text,
                Webpage = this.WebPageTextBox.Text
            };
            controller.repository.ListenerSet.Add(newChair);
            controller.repository.SaveChanges();
            this.Close();
            var createConference = new CreateConference(controller, newChair);
            createConference.Show();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var user = getUser(LogInPasswordTextBox.Text, LogInPasswordTextBox.Text);
            var reviewers = controller.repository.ListenerSet.OfType<ConferenceChair>();
            if (reviewers.ToList().Contains(user))
            {
                this.Close();
                var createConference = new CreateConference(controller, (ConferenceChair)user);
                createConference.Show();
            }
            else
            {
                MessageBox.Show("Invalid data!", "Error");
            }
        }
    }
}
