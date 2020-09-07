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
    public partial class CreateConference : Form
    {
        private Controller.Controller controller = null;
        private ConferenceChair newChair = null;
        public CreateConference(Controller.Controller controller, ConferenceChair newChair)
        {
            InitializeComponent();
            this.controller = controller;
            controller.repository.ConferenceSet.Load();
            this.newChair = newChair;
        }

        private void CreateConference_Load(object sender, EventArgs e)
        {

        }

        private void CreateConferenceButton_Click(object sender, EventArgs e)
        {
            if (this.ConferenceNameTextBox.Text.Equals(""))
            {
                MessageBox.Show("Username can't be empty");
                return;
            }

            if (!this.StartDatePicker.Checked)
            {
                MessageBox.Show("Select Start Date!");
                return;
            }

            if (!this.EndDatePicker.Checked)
            {
                MessageBox.Show("Select End Date!");
                return;
            }

            if (!this.AbstractPicker.Checked)
            {
                MessageBox.Show("Select abstract deadline!");
                return;
            }

            if (!this.PaperPicker.Checked)
            {
                MessageBox.Show("Select paper deadline!");
                return;
            }

            if (!this.BiddingPicker.Checked)
            {
                MessageBox.Show("Select bidding deadline!");
                return;
            }

            if (!this.EvaluationPicker.Checked)
            {
                MessageBox.Show("Select evaluation deadline!");
                return;
            }

        
            int year = this.StartDatePicker.Value.Year;
            int month = this.StartDatePicker.Value.Month;
            int day = this.StartDatePicker.Value.Day;
            int hour = this.StartDatePicker.Value.Hour;
            int minute = this.StartDatePicker.Value.Minute;
            int second = this.StartDatePicker.Value.Second;
            DateTime startDate = new DateTime(year, month, day, hour, minute, second);

            year = this.EndDatePicker.Value.Year;
            month = this.EndDatePicker.Value.Month;
            day = this.EndDatePicker.Value.Day;
            hour = this.EndDatePicker.Value.Hour;
            minute = this.EndDatePicker.Value.Minute;
            second = this.EndDatePicker.Value.Second;
            DateTime endDate = new DateTime(year, month, day, hour, minute, second);

            year = this.AbstractPicker.Value.Year;
            month = this.AbstractPicker.Value.Month;
            day = this.AbstractPicker.Value.Day;
            hour = this.AbstractPicker.Value.Hour;
            minute = this.AbstractPicker.Value.Minute;
            second = this.AbstractPicker.Value.Second;
            DateTime abstractDeadline = new DateTime(year, month, day, hour, minute, second);

            year = this.PaperPicker.Value.Year;
            month = this.PaperPicker.Value.Month;
            day = this.PaperPicker.Value.Day;
            hour = this.PaperPicker.Value.Hour;
            minute = this.PaperPicker.Value.Minute;
            second = this.PaperPicker.Value.Second;
            DateTime paperDeadline = new DateTime(year, month, day, hour, minute, second);

            year = this.BiddingPicker.Value.Year;
            month = this.BiddingPicker.Value.Month;
            day = this.BiddingPicker.Value.Day;
            hour = this.BiddingPicker.Value.Hour;
            minute = this.BiddingPicker.Value.Minute;
            second = this.BiddingPicker.Value.Second;
            DateTime biddingDeadline = new DateTime(year, month, day, hour, minute, second);

            year = this.EvaluationPicker.Value.Year;
            month = this.EvaluationPicker.Value.Month;
            day = this.EvaluationPicker.Value.Day;
            hour = this.EvaluationPicker.Value.Hour;
            minute = this.EvaluationPicker.Value.Minute;
            second = this.EvaluationPicker.Value.Second;
            DateTime evaluationDeadline = new DateTime(year, month, day, hour, minute, second);

            Conference newConference = new Conference
            {
                Name = this.ConferenceNameTextBox.Text,
                StartDate = startDate,
                EndDate = endDate,
                AbstractDeadline = abstractDeadline,
                PaperDeadline = paperDeadline,
                BiddingDeadline = biddingDeadline,
                EvaluationDeadline = evaluationDeadline,
                ConferenceChair = newChair
            };

            newConference.Listeners.Add(newChair);
            newConference.Reviewers.Add(newChair);

            controller.repository.ConferenceSet.Add(newConference);
            controller.repository.SaveChanges();
            this.Close();

        }
    }
}
