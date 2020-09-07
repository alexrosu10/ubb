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
    public partial class ReviewerWindow : Form
    {
        private Controller.Controller ctrl;
        private Reviewer reviewer;
        private Conference conf;
        public ReviewerWindow(Reviewer reviewer,Conference conf,Controller.Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.reviewer = reviewer;
            this.conf = conf;
            var context = this.ctrl.repository;
            DateTime currentDateTime = DateTime.Now;
            if (DateTime.Compare(currentDateTime,conf.BiddingDeadline) < 0)
            {
                //if we are currently before the abstract bidding deadline
                //show abstract related stuff
                abstractsLabel.Show();
                abstractsSaveButton.Show();
                abstractGridView.Show();
                //hide everything else
                papersLabel.Hide();
                papersSaveButton.Hide();
                papersGridView.Hide();

                sessionsLabel.Hide();
                createSessionButton.Hide();
                sessionsGridView.Hide();

                //then fill with the info
                var abstracts = context.AbstractSet.ToList();
                var authors = new Dictionary<Abstract, String>();
                Abstract thisAuthorsAbstract = abstracts.Find(a => a.Authors.Contains((Author)this.reviewer));
                if (thisAuthorsAbstract != null)
                {
                    abstracts.Remove(thisAuthorsAbstract);
                }
                foreach (Abstract abs in abstracts)
                {
                    var authorString = "";
                    foreach (Author auth in abs.Authors)
                        authorString += auth.Name + ",";
                    authorString = authorString.Remove(authorString.Length - 1);
                    authors[abs] = authorString;
                }
                if (!(abstracts.Capacity == 0))
                    this.abstractGridView.DataSource =
                        abstracts.Select(a => new { a.Id, a.Name, a.Keywords, a.Topics, a.Description, Authors = authors[a] }).ToList();
                DataGridViewCheckBoxColumn bidColumn = new DataGridViewCheckBoxColumn();
                bidColumn.HeaderText = "Bid";
                bidColumn.Name = "bidColumn";
                abstractGridView.Columns.Add(bidColumn);
            }
            else if(DateTime.Compare(currentDateTime,conf.EvaluationDeadline) < 0)
            {
                //if we are currently before the paper evaluation deadline
                //show paper related stuff
                papersLabel.Show();
                papersSaveButton.Show();
                papersGridView.Show();
                //hide everything else
                abstractsLabel.Hide();
                abstractsSaveButton.Hide();
                abstractGridView.Hide();

                sessionsLabel.Hide();
                createSessionButton.Hide();
                sessionsGridView.Hide();

                //then fill with the info
                var abstracts = context.AbstractSet.ToList();
                var specificPapers = new List<Paper>();
                foreach (Abstract abs in abstracts)
                {
                    var absBid = abs.AbstractBidding.ToList().Find(ab => ab.ReviewerId == this.reviewer.Id);
                    if(absBid != null)
                        specificPapers.Add(abs.Paper);
                }
                if (!(specificPapers.Capacity == 0))
                    this.papersGridView.DataSource =
                        specificPapers.Select(p => new { p.Id, p.Name }).ToList();

                //add the open file button
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Text = "Open";
                buttonColumn.Name = "buttonColumn";
                buttonColumn.HeaderText = "File";
                buttonColumn.UseColumnTextForButtonValue = true;
                papersGridView.Columns.Add(buttonColumn);

                //add the selection combo box
                DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.HeaderText = "Evaluation";
                comboColumn.Name = "comboColumn";
                comboColumn.Items.Add("Strong accept");
                comboColumn.Items.Add("Accept");
                comboColumn.Items.Add("Weak accept");
                comboColumn.Items.Add("Borderline");
                comboColumn.Items.Add("Weak reject");
                comboColumn.Items.Add("Reject");
                comboColumn.Items.Add("Strong reject");
                comboColumn.DisplayIndex = 3;
                papersGridView.Columns.Add(comboColumn);

                //add the recommendation column
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.Name = "textColumn";
                textColumn.HeaderText = "Recommendations";
                papersGridView.Columns.Add(textColumn);
            }
            else
            {
                //if we are currently after the paper evaluation deadline
                //show session related stuff
                sessionsLabel.Show();
                createSessionButton.Show();
                sessionsGridView.Show();
                //hide everything else
                abstractsLabel.Hide();
                abstractsSaveButton.Hide();
                abstractGridView.Hide();

                papersLabel.Hide();
                papersSaveButton.Hide();
                papersGridView.Hide();

                //then fill with the info

            }
        }

        private void abstractsSaveButton_Click(object sender, EventArgs e)
        {
            var context = this.ctrl.repository;
            foreach (DataGridViewRow row in abstractGridView.Rows)
            {
                var chBoxCell = row.Cells[6] as DataGridViewCheckBoxCell;
                if (chBoxCell.Value != null)
                {
                    if (Convert.ToBoolean(chBoxCell.Value) == true)
                    {
                         
                        AbstractBidding ab = new AbstractBidding();
                        int abstractId;
                        int.TryParse(row.Cells[0].Value.ToString(),out abstractId);
                        Abstract abs = context.AbstractSet.ToList().Find(a => a.Id == abstractId);
                        int reviewerId = this.reviewer.Id;
                        ab.Abstract = abs;
                        ab.AbstractId = abstractId;
                        ab.ReviewerId = reviewerId;
                        ab.Reviewer = this.reviewer;
                        context.AbstractBiddingSet.Add(ab); 
                    }
                    else
                    {
                        AbstractBidding absBid = context.AbstractBiddingSet.ToList().Find(ab => ab.AbstractId ==
                        int.Parse(row.Cells[0].Value.ToString()) && ab.ReviewerId == this.reviewer.Id);
                        if (absBid != null)
                            context.AbstractBiddingSet.Remove(absBid);
                    }
                }
            }
            context.SaveChanges();
        }

        private void papersGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var context = ctrl.repository;
            if (e.ColumnIndex == papersGridView.Columns["buttonColumn"].Index)
            {
                var path = context.PaperSet.Find(int.Parse(papersGridView.Rows[e.RowIndex].Cells[0].Value.ToString())).Content;
                System.Diagnostics.Process.Start(path);
            }
        }

        private void papersSaveButton_Click(object sender, EventArgs e)
        {
            var context = this.ctrl.repository;
            foreach(DataGridViewRow row in papersGridView.Rows)
            {
                var comboCell = row.Cells["comboColumn"] as DataGridViewComboBoxCell;
                var recomCell = row.Cells["textColumn"] as DataGridViewTextBoxCell;
                if(comboCell.Value != null)
                {
                    PaperReview pr = new PaperReview();
                    int paperId = 0;
                    int.TryParse(row.Cells[0].Value.ToString(),out paperId);
                    var paper = context.PaperSet.ToList().Find(p=>p.Id == paperId);
                    var revId = this.reviewer.Id;
                    pr.PaperId = paperId;
                    pr.ReviewerId = revId;
                    pr.Paper = paper;
                    pr.Reviewer = this.reviewer;
                    pr.Evaluation = comboCell.Value.ToString();
                    if (recomCell.Value != null)
                        pr.Recommendations = recomCell.Value.ToString();
                    context.PaperReviewSet.Add(pr);
                }
            }
            context.SaveChanges();
        }
    }
}
