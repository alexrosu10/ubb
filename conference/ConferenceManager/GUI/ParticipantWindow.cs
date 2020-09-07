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
    public partial class ParticipantWindow : Form
    {
        private Listener listener;
        private Controller.Controller ctrl;
        public ParticipantWindow(Listener listener,Controller.Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.listener = listener;
            this.Text = listener.Username;

            var context = this.ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            var authors = new Dictionary<Abstract, String>();
            //filling the abstract gridView
            foreach(Abstract abs in abstracts)
            {
                var authorString = "";
                foreach(Author auth in abs.Authors)
                    authorString += auth.Name + ",";
                authorString = authorString.Remove(authorString.Length - 1);
                authors[abs] = authorString;
            }
            if(!(abstracts.Capacity == 0))
                this.abstractsGridView.DataSource = 
                    abstracts.Select(a => new { a.Id, a.Name, a.Keywords, a.Topics, a.Description,Authors = authors[a] }).ToList();
            var sessions = context.SessionSet.ToList();
            //filling the session gridView
            var speakers = new Dictionary<Session, string>();
            foreach (Session ses in sessions)
            {
                var authorString = "";
                foreach (Author auth in ses.Speakers)
                    authorString += auth.Name + ",";
                authorString = authorString.Remove(authorString.Length - 1);
                speakers[ses] = authorString;
            }
            var papers = new Dictionary<Session, String>();
            foreach (Session ses in sessions)
            {
                var paperString = "";
                foreach (Paper pap in ses.Papers)
                    paperString += pap.Name + ",";
                paperString = paperString.Remove(paperString.Length - 1);
                papers[ses] = paperString;
            }
            if (!(sessions.Capacity == 0))
                this.sessionsGridView.DataSource =
                    sessions.Select(s => new { s.Id, s.Place, SessionChair = s.SessionChair.Name, s.Time, Speakers = speakers[s], Papers = papers[s] }).ToList();
        }

        private void refreshAllButton_Click(object sender, EventArgs e)
        {
            var context = this.ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            var authors = new Dictionary<Abstract, String>();
            //filling the abstract gridView
            foreach (Abstract abs in abstracts)
            {
                var authorString = "";
                foreach (Author auth in abs.Authors)
                    authorString += auth.Name + ",";
                authorString = authorString.Remove(authorString.Length - 1);
                authors[abs] = authorString;
            }
            if (!(abstracts.Capacity == 0))
                this.abstractsGridView.DataSource =
                    abstracts.Select(a => new { a.Id, a.Name, a.Keywords, a.Topics, a.Description, Authors = authors[a] }).ToList();
            var sessions = context.SessionSet.ToList();
            //filling the session gridView
            var speakers = new Dictionary<Session, string>();
            foreach (Session ses in sessions)
            {
                var authorString = "";
                foreach (Author auth in ses.Speakers)
                    authorString += auth.Name + ",";
                authorString = authorString.Remove(authorString.Length - 1);
                speakers[ses] = authorString;
            }
            var papers = new Dictionary<Session, String>();
            foreach (Session ses in sessions)
            {
                var paperString = "";
                foreach (Paper pap in ses.Papers)
                    paperString += pap.Name + ",";
                paperString = paperString.Remove(paperString.Length - 1);
                papers[ses] = paperString;
            }
            if (!(sessions.Capacity == 0))
                this.sessionsGridView.DataSource =
                    sessions.Select(s => new { s.Id, s.Place, SessionChair = s.SessionChair.Name, s.Time, Speakers = speakers[s], Papers = papers[s] }).ToList();
        }

        private void refreshAbstractsButton_Click(object sender, EventArgs e)
        {
            var context = this.ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            var authors = new Dictionary<Abstract, String>();
            //filling the abstract gridView
            foreach (Abstract abs in abstracts)
            {
                var authorString = "";
                foreach (Author auth in abs.Authors)
                    authorString += auth.Name + ",";
                authorString = authorString.Remove(authorString.Length - 1);
                authors[abs] = authorString;
            }
            if (!(abstracts.Capacity == 0))
                this.abstractsGridView.DataSource =
                    abstracts.Select(a => new { a.Id, a.Name, a.Keywords, a.Topics, a.Description, Authors = authors[a] }).ToList();
        }

        private void refreshSessionsButton_Click(object sender, EventArgs e)
        {
            var context = this.ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            var sessions = context.SessionSet.ToList();
            //filling the session gridView
            var speakers = new Dictionary<Session, string>();
            foreach (Session ses in sessions)
            {
                var authorString = "";
                foreach (Author auth in ses.Speakers)
                    authorString += auth.Name + ",";
                authorString = authorString.Remove(authorString.Length - 1);
                speakers[ses] = authorString;
            }
            var papers = new Dictionary<Session, String>();
            foreach (Session ses in sessions)
            {
                var paperString = "";
                foreach (Paper pap in ses.Papers)
                    paperString += pap.Name + ",";
                paperString = paperString.Remove(paperString.Length - 1);
                papers[ses] = paperString;
            }
            if (!(sessions.Capacity == 0))
                this.sessionsGridView.DataSource =
                    sessions.Select(s => new { s.Id, s.Place, SessionChair = s.SessionChair.Name, s.Time, Speakers = speakers[s], Papers = papers[s] }).ToList();

        }
    }
}
