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
    public partial class AuthorConferenceWindow : Form
    {
        private Listener user = null;
        private Conference conference = null;
        public AuthorConferenceWindow(Conference conference, Author user)
        {
            InitializeComponent();
            this.conference = conference;
            this.user = user;
        }

        private void AuthorConferenceWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
