using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using ConferenceManager.Controller;
using ConferenceManager.ConferenceManager.GUI;
using MainMenu = ConferenceManager.ConferenceManager.GUI.MainMenu;

namespace ConferenceManager
{
    public partial class LogInWindow : Form
    {
        private Conference conference;
        private Controller.Controller ctrl;

        private bool checkInput()
        {
            if (UsernameTextBox.TextLength == 0 || PasswordTextBox.TextLength == 0)
                return false;
            return true;
        }

        private Listener getUser(string name, string password)
        {
            var context = ctrl.repository;
            var info = context.ListenerSet.ToList();
            foreach (var user in info)
            {
                
                 if (user.Username == name && user.Password == password)
                   return user;
            }
            return null;
        }

        public LogInWindow(Conference conference,Controller.Controller ctrl)
        {
            InitializeComponent();
            this.conference = conference;
            this.ctrl = ctrl;
        }

        private void LogInWindow_Load(object sender, EventArgs e)
        {
            this.accountTypeCombo.SelectedIndex = 0;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            /*
             *Check the input values and inform the user if the input is invalid
             */
            if (!checkInput())
            {
                MessageBox.Show("Empty fields!", "Error");
                return;
            }

            var user = getUser(UsernameTextBox.Text, PasswordTextBox.Text);
            if (user == null)
            {
                MessageBox.Show("Invalid info!", "Error");
                return;
            }

            if (this.accountTypeCombo.SelectedItem.ToString() == "Participant")
            {
                MessageBox.Show("Success!");
                new ParticipantWindow(user,ctrl).Show();

                this.Close();
                
            }
            else if (this.accountTypeCombo.SelectedItem.ToString() == "Author" && isAuthor(user))
            {
                MessageBox.Show("Success!");
                new AuthorWindow((Author)user,ctrl).Show();

                this.Close();
            }
            else if (this.accountTypeCombo.SelectedItem.ToString() == "Program Committee Member" && isReviewer(user))
            {
                MessageBox.Show("Success!");
                if (user.Id == conference.ConferenceChairId)
                {
                    //Create and open Chair window for current conference
                }
                else
                {
                    new ReviewerWindow((Reviewer)user, this.conference, ctrl).Show();
                }


                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid info!", "Error");
            }
           
        }

        private bool isAuthor(Listener user)
        {
            foreach (var author in ctrl.repository.ListenerSet.OfType<Author>().ToList())
            {
                if (author.Id == user.Id)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isReviewer(Listener user)
        {
            foreach (var reviewer in ctrl.repository.ListenerSet.OfType<Reviewer>().ToList())
            {
                if (reviewer.Id == user.Id)
                {
                    return true;
                }
            }

            return false;
        }

        private void newAccount_Click(object sender, EventArgs e)
        {
            /*
             * Pop up another window that will let the user create an account
             */
            new CreateAccount(ctrl).Show();
        }

       
    }
}
