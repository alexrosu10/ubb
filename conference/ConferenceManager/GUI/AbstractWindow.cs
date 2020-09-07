using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferenceManager.ConferenceManager.GUI
{
    public partial class AbstractWindow : Form
    {
        private Author initialAuthor;
        Abstract abs;
        private Controller.Controller ctrl;

        public AbstractWindow(Author author,Abstract abs,Controller.Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.abs = abs;
            this.initialAuthor=author;
            this.nameField.Text=abs.Name;
            this.topicsField.Text = abs.Topics;
            this.keywordsField.Text = abs.Keywords;
            this.descriptionField.Text = abs.Description;
            string auth = "";
            foreach(Author au in abs.Authors)
            {
                auth += au.Username + ',';
            }
            if (auth.Length != 0)
            {
                auth.Remove(auth.Length-1);
            }
            this.authorsField.Text = auth;
        }

        private bool addAuthors(String authorText,Abstract abs)
        {
            List<String> authors = authorText.Split(',').ToList();
            var accountsList = ctrl.repository;
            var info = accountsList.ListenerSet.ToList();
            List<Author> toBeAdded = new List<Author>();
            int size = 0;
            foreach (var username in authors)
            {
                foreach (Author a in info)
                {
                    if (a.Username == username)
                    {
                        size++;
                        toBeAdded.Add(a);
                    }
                }
            }
            if (size == authors.Count)
            {
                toBeAdded.Add(initialAuthor);
                foreach(Author auth in toBeAdded)
                {
                    if(!abs.Authors.Contains(auth))
                        abs.Authors.Add(auth);
                }
                return true;
            }
            return false;
        }

        private bool checkTexts()
        {
            int errors = 0;
            if (descriptionField.Text == "")
                errors++;
            if (keywordsField.Text == "")
                errors++;
            if (topicsField.Text == "")
                errors++;
            if (errors == 0)
                return true;
            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var context = ctrl.repository;
            if (this.checkTexts() == false)
            {
                MessageBox.Show("Only the authors field is optional! Everything else is mandatory!", "Error!");
                return;
            }
            abs.Name = nameField.Text;
            abs.Description = descriptionField.Text;
            abs.Keywords = keywordsField.Text;
            abs.Topics = topicsField.Text;
            if (authorsField.Text != "") {
                if (this.addAuthors(authorsField.Text, abs) == false)
                {
                    MessageBox.Show("Incorrect author usernames! Either type valid usernames or leave field blank!", "Error!");
                    return;
                }
                
            }
            else if (!abs.Authors.Contains(initialAuthor))
            {
                abs.Authors.Add(initialAuthor);
            }
            var toBeUpdated = context.AbstractSet.Find(abs.Id);
            if (toBeUpdated == null)
            {
                context.AbstractSet.Add(abs);
            }
            else
            {
                toBeUpdated.Name = abs.Name;
                toBeUpdated.Topics = abs.Topics;
                toBeUpdated.Keywords = abs.Keywords;
                toBeUpdated.Authors = abs.Authors;
            }
            context.SaveChanges();
            MessageBox.Show("Success!", "Message");
            this.Close();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            if(abs.Paper == null)
            {
                var pap = new Paper();
                abs.Paper = pap;
                pap.Name = abs.Name;
                pap.Abstract = abs;
                ctrl.repository.PaperSet.Add(pap);
                ctrl.repository.SaveChanges();
                PaperWindow pw = new PaperWindow(pap,ctrl);
                pw.Show();
            }
            else
            {
                PaperWindow pw = new PaperWindow(abs.Paper, ctrl);
                pw.Show();
            }
        }
    }
}
