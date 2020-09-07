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
    public partial class AuthorWindow : Form
    {
        private Author author;
        private Controller.Controller ctrl;

        public AuthorWindow(Author author,Controller.Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.author = author;
            this.Text = this.author.Name;
            
            var context = this.ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            var specificAbstracts = new List<Abstract>();
            foreach(Abstract abs in abstracts)
            {
                if (abs.Authors.Contains(author))
                    specificAbstracts.Add(abs);
            }
            if(!(specificAbstracts.Capacity==0))
            this.dataGridView1.DataSource =
                specificAbstracts.Select(a => new { a.Id, a.Name, a.Keywords, a.Topics, a.Description }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
            */
            AbstractWindow aw = new AbstractWindow(author,new Abstract(),ctrl);
            aw.Show();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var context = ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Abstract abs = abstracts.Find(a => a.Id == id);
            AbstractWindow aw = new AbstractWindow(author, abs, ctrl);
            aw.Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            var context = this.ctrl.repository;
            var abstracts = context.AbstractSet.ToList();
            var specificAbstracts = new List<Abstract>();
            foreach (Abstract abs in abstracts)
            {
                if (abs.Authors.Contains(author))
                    specificAbstracts.Add(abs);
            }
            if (!(specificAbstracts.Capacity == 0))
                this.dataGridView1.DataSource =
                    specificAbstracts.Select(a => new { a.Id, a.Name, a.Keywords, a.Topics, a.Description }).ToList();
        }
    }
}
