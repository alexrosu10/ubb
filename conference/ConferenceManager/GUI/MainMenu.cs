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
    public partial class MainMenu : Form
    {
        private Controller.Controller controller = null;
        private DbSet<Conference> conferences { get; }

        public MainMenu(Controller.Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
            conferences = ctrl.repository.ConferenceSet;
            conferences.Load();

            this.ConferenceGrid.DataSource =
                conferences.Select(c => new {c.Name, c.StartDate, c.EndDate, Chair = c.ConferenceChair.Name}).ToList();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void CreateConferenceButton_Click(object sender, EventArgs e)
        {
            var createChairAccount = new CreateChairAccount(controller);
            createChairAccount.Show();
        }

        private void ConferenceGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var loginWindow = new LogInWindow(conferences.ToList().ElementAt(ConferenceGrid.CurrentCell.RowIndex),controller);
            loginWindow.Show();
            
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            conferences.Load();

            this.ConferenceGrid.DataSource =
                conferences.Select(c => new { c.Name, c.StartDate, c.EndDate, Chair = c.ConferenceChair.Name }).ToList();
        }
    }
}
