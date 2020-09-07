namespace ConferenceManager.ConferenceManager.GUI
{
    partial class CreateConference
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.ConferenceNameTextBox = new System.Windows.Forms.TextBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.ConferenceNameLabel = new System.Windows.Forms.Label();
            this.CreateConferenceButton = new System.Windows.Forms.Button();
            this.PaperLabel = new System.Windows.Forms.Label();
            this.AbstractLabel = new System.Windows.Forms.Label();
            this.EvaluationLabel = new System.Windows.Forms.Label();
            this.BiddingLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AbstractPicker = new System.Windows.Forms.DateTimePicker();
            this.PaperPicker = new System.Windows.Forms.DateTimePicker();
            this.BiddingPicker = new System.Windows.Forms.DateTimePicker();
            this.EvaluationPicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateLabel.Location = new System.Drawing.Point(29, 83);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(71, 17);
            this.EndDateLabel.TabIndex = 49;
            this.EndDateLabel.Text = "End Date:";
            // 
            // ConferenceNameTextBox
            // 
            this.ConferenceNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConferenceNameTextBox.Location = new System.Drawing.Point(176, 25);
            this.ConferenceNameTextBox.Name = "ConferenceNameTextBox";
            this.ConferenceNameTextBox.Size = new System.Drawing.Size(200, 23);
            this.ConferenceNameTextBox.TabIndex = 48;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateLabel.Location = new System.Drawing.Point(29, 54);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(76, 17);
            this.StartDateLabel.TabIndex = 46;
            this.StartDateLabel.Text = "Start Date:";
            // 
            // ConferenceNameLabel
            // 
            this.ConferenceNameLabel.AutoSize = true;
            this.ConferenceNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConferenceNameLabel.Location = new System.Drawing.Point(29, 25);
            this.ConferenceNameLabel.Name = "ConferenceNameLabel";
            this.ConferenceNameLabel.Size = new System.Drawing.Size(126, 17);
            this.ConferenceNameLabel.TabIndex = 45;
            this.ConferenceNameLabel.Text = "Conference Name:";
            // 
            // CreateConferenceButton
            // 
            this.CreateConferenceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateConferenceButton.Location = new System.Drawing.Point(29, 257);
            this.CreateConferenceButton.Name = "CreateConferenceButton";
            this.CreateConferenceButton.Size = new System.Drawing.Size(110, 23);
            this.CreateConferenceButton.TabIndex = 44;
            this.CreateConferenceButton.Text = "Create Conference";
            this.CreateConferenceButton.UseVisualStyleBackColor = true;
            this.CreateConferenceButton.Click += new System.EventHandler(this.CreateConferenceButton_Click);
            // 
            // PaperLabel
            // 
            this.PaperLabel.AutoSize = true;
            this.PaperLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaperLabel.Location = new System.Drawing.Point(29, 141);
            this.PaperLabel.Name = "PaperLabel";
            this.PaperLabel.Size = new System.Drawing.Size(110, 17);
            this.PaperLabel.TabIndex = 53;
            this.PaperLabel.Text = "Paper Deadline:";
            // 
            // AbstractLabel
            // 
            this.AbstractLabel.AutoSize = true;
            this.AbstractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbstractLabel.Location = new System.Drawing.Point(29, 112);
            this.AbstractLabel.Name = "AbstractLabel";
            this.AbstractLabel.Size = new System.Drawing.Size(122, 17);
            this.AbstractLabel.TabIndex = 51;
            this.AbstractLabel.Text = "Abstract deadline:";
            // 
            // EvaluationLabel
            // 
            this.EvaluationLabel.AutoSize = true;
            this.EvaluationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EvaluationLabel.Location = new System.Drawing.Point(29, 199);
            this.EvaluationLabel.Name = "EvaluationLabel";
            this.EvaluationLabel.Size = new System.Drawing.Size(143, 17);
            this.EvaluationLabel.TabIndex = 57;
            this.EvaluationLabel.Text = "Evaluation DeadLine:";
            // 
            // BiddingLabel
            // 
            this.BiddingLabel.AutoSize = true;
            this.BiddingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BiddingLabel.Location = new System.Drawing.Point(29, 170);
            this.BiddingLabel.Name = "BiddingLabel";
            this.BiddingLabel.Size = new System.Drawing.Size(119, 17);
            this.BiddingLabel.TabIndex = 55;
            this.BiddingLabel.Text = "Bidding Deadline:";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(176, 54);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDatePicker.TabIndex = 59;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(176, 83);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDatePicker.TabIndex = 60;
            // 
            // AbstractPicker
            // 
            this.AbstractPicker.Location = new System.Drawing.Point(176, 112);
            this.AbstractPicker.Name = "AbstractPicker";
            this.AbstractPicker.Size = new System.Drawing.Size(200, 20);
            this.AbstractPicker.TabIndex = 61;
            // 
            // PaperPicker
            // 
            this.PaperPicker.Location = new System.Drawing.Point(176, 141);
            this.PaperPicker.Name = "PaperPicker";
            this.PaperPicker.Size = new System.Drawing.Size(200, 20);
            this.PaperPicker.TabIndex = 62;
            // 
            // BiddingPicker
            // 
            this.BiddingPicker.Location = new System.Drawing.Point(176, 170);
            this.BiddingPicker.Name = "BiddingPicker";
            this.BiddingPicker.Size = new System.Drawing.Size(200, 20);
            this.BiddingPicker.TabIndex = 63;
            // 
            // EvaluationPicker
            // 
            this.EvaluationPicker.Location = new System.Drawing.Point(176, 199);
            this.EvaluationPicker.Name = "EvaluationPicker";
            this.EvaluationPicker.Size = new System.Drawing.Size(200, 20);
            this.EvaluationPicker.TabIndex = 64;
            // 
            // CreateConference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EvaluationPicker);
            this.Controls.Add(this.BiddingPicker);
            this.Controls.Add(this.PaperPicker);
            this.Controls.Add(this.AbstractPicker);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.EvaluationLabel);
            this.Controls.Add(this.BiddingLabel);
            this.Controls.Add(this.PaperLabel);
            this.Controls.Add(this.AbstractLabel);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.ConferenceNameTextBox);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.ConferenceNameLabel);
            this.Controls.Add(this.CreateConferenceButton);
            this.Name = "CreateConference";
            this.Text = "Create Conference";
            this.Load += new System.EventHandler(this.CreateConference_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.TextBox ConferenceNameTextBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label ConferenceNameLabel;
        private System.Windows.Forms.Button CreateConferenceButton;
        private System.Windows.Forms.Label PaperLabel;
        private System.Windows.Forms.Label AbstractLabel;
        private System.Windows.Forms.Label EvaluationLabel;
        private System.Windows.Forms.Label BiddingLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.DateTimePicker AbstractPicker;
        private System.Windows.Forms.DateTimePicker PaperPicker;
        private System.Windows.Forms.DateTimePicker BiddingPicker;
        private System.Windows.Forms.DateTimePicker EvaluationPicker;
    }
}