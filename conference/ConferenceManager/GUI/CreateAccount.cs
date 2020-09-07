using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferenceManager
{
    public partial class CreateAccount : Form
    {
        private Controller.Controller ctrl;

        public CreateAccount(Controller.Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        private bool checkInput()
        {
            string errors = "";
            if (UsernameTextBox.TextLength < 1)
                errors += "Username must not be empty!\n";
            if (PasswordTextBox.TextLength < 1)
                errors += "Password must not be empty!\n";
            if (RetypeTextBox.Text != PasswordTextBox.Text)
                errors += "Passwords does not match !\n";
            if(accountTypeCombo.SelectedItem.ToString().Equals("Author") || accountTypeCombo.SelectedItem.ToString().Equals("Program Committee Member"))
            {
                if (FirstNameTextBox.TextLength < 1)
                    errors += "First name must not be empty!\n";
                if (LastNameTextBox.TextLength < 1)
                    errors += "Last name must not be empty!\n";
                if (AffiliationTextBox.TextLength < 1)
                    errors += "Affiliation must not be empty!\n";
                if (EmailTextBox.TextLength < 1)
                    errors += "Email must not be empty!\n";
                if (accountTypeCombo.SelectedItem.ToString().Equals("Program Committee Member"))
                {
                    if (WebPageTextBox.TextLength < 1)
                        errors += "Web page must not be empty!\n";
                }
            }
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors, "Error !");
                return false;
            }
            return true;
        }

        private bool userExists(string username)
        {
            var accountsList = ctrl.repository;
            var info = accountsList.ListenerSet.ToList();
            foreach (var a in info)
            {
                if (a.Username == username)
                    return true;
            }
            return false;
        }

        private void addToDataBase(int option)
        {
            var accountsList = ctrl.repository;
            if (option == 2)
            {
                var listener = new Listener()
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text
                };
                accountsList.ListenerSet.Add(listener);
                accountsList.SaveChanges();
            }
            else if (option == 1)
            {
                var listener = new Author()
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    Name = FirstNameTextBox.Text + LastNameTextBox.Text,
                    Affiliation = AffiliationTextBox.Text,
                    Email = EmailTextBox.Text
                };
                accountsList.ListenerSet.Add(listener);
                accountsList.SaveChanges();
            }
            else
            {
                var listener = new Reviewer()
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    Name = FirstNameTextBox.Text + LastNameTextBox.Text,
                    Affiliation = AffiliationTextBox.Text,
                    Email = EmailTextBox.Text,
                    Webpage = WebPageTextBox.Text
                };
                accountsList.ListenerSet.Add(listener);
                accountsList.SaveChanges();
            }
        }

        private void createAccount_Click(object sender, EventArgs e)
        {
            /*
             * Check the input and print errors to the user, if any
             * If everything passes validation, add the user to the repo
             */

            if (!checkInput())
            {
                return;
            }

            if (userExists(UsernameTextBox.Text))
            {
                MessageBox.Show("User already exists!", "Error");
            }
            else
            {
                addToDataBase(this.accountTypeCombo.SelectedIndex);
                MessageBox.Show("Added to database!");
            }
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            this.accountTypeCombo.SelectedIndex = 0;
        }

        private void AccountTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.accountTypeCombo.SelectedIndex == 0)
            {
                this.FirstNameLabel.Show();
                this.FirstNameTextBox.Show();
                this.LastNameLabel.Show();
                this.LastNameTextBox.Show();
                this.AffiliationLabel.Show();
                this.AffiliationTextBox.Show();
                this.EmailLabel.Show();
                this.EmailTextBox.Show();
                this.WebPageLabel.Show();
                this.WebPageTextBox.Show();
            }
            else if (this.accountTypeCombo.SelectedIndex == 1)
            {
                this.FirstNameLabel.Show();
                this.FirstNameTextBox.Show();
                this.LastNameLabel.Show();
                this.LastNameTextBox.Show();
                this.AffiliationLabel.Show();
                this.AffiliationTextBox.Show();
                this.EmailLabel.Show();
                this.EmailTextBox.Show();
                this.WebPageLabel.Hide();
                this.WebPageTextBox.Hide();
            }
            else if (this.accountTypeCombo.SelectedIndex == 2)
            {
                this.FirstNameLabel.Hide();
                this.FirstNameTextBox.Hide();
                this.LastNameLabel.Hide();
                this.LastNameTextBox.Hide();
                this.AffiliationLabel.Hide();
                this.AffiliationTextBox.Hide();
                this.EmailLabel.Hide();
                this.EmailTextBox.Hide();
                this.WebPageLabel.Hide();
                this.WebPageTextBox.Hide();
            }
        }
    }
}
