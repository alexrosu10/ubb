namespace ConferenceManager.ConferenceManager.GUI
{
    partial class ReviewerWindow
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
            this.abstractsLabel = new System.Windows.Forms.Label();
            this.abstractGridView = new System.Windows.Forms.DataGridView();
            this.papersLabel = new System.Windows.Forms.Label();
            this.papersGridView = new System.Windows.Forms.DataGridView();
            this.sessionsGridView = new System.Windows.Forms.DataGridView();
            this.sessionsLabel = new System.Windows.Forms.Label();
            this.abstractsSaveButton = new System.Windows.Forms.Button();
            this.papersSaveButton = new System.Windows.Forms.Button();
            this.createSessionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.abstractGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.papersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // abstractsLabel
            // 
            this.abstractsLabel.AutoSize = true;
            this.abstractsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.abstractsLabel.Location = new System.Drawing.Point(12, 9);
            this.abstractsLabel.Name = "abstractsLabel";
            this.abstractsLabel.Size = new System.Drawing.Size(85, 22);
            this.abstractsLabel.TabIndex = 0;
            this.abstractsLabel.Text = "Abstracts";
            // 
            // abstractGridView
            // 
            this.abstractGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.abstractGridView.Location = new System.Drawing.Point(16, 34);
            this.abstractGridView.Name = "abstractGridView";
            this.abstractGridView.Size = new System.Drawing.Size(520, 176);
            this.abstractGridView.TabIndex = 3;
            // 
            // papersLabel
            // 
            this.papersLabel.AutoSize = true;
            this.papersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.papersLabel.Location = new System.Drawing.Point(16, 227);
            this.papersLabel.Name = "papersLabel";
            this.papersLabel.Size = new System.Drawing.Size(67, 22);
            this.papersLabel.TabIndex = 4;
            this.papersLabel.Text = "Papers";
            // 
            // papersGridView
            // 
            this.papersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.papersGridView.Location = new System.Drawing.Point(20, 252);
            this.papersGridView.Name = "papersGridView";
            this.papersGridView.Size = new System.Drawing.Size(516, 173);
            this.papersGridView.TabIndex = 5;
            this.papersGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.papersGridView_CellClick);
            // 
            // sessionsGridView
            // 
            this.sessionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionsGridView.Location = new System.Drawing.Point(20, 473);
            this.sessionsGridView.Name = "sessionsGridView";
            this.sessionsGridView.Size = new System.Drawing.Size(516, 173);
            this.sessionsGridView.TabIndex = 7;
            // 
            // sessionsLabel
            // 
            this.sessionsLabel.AutoSize = true;
            this.sessionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sessionsLabel.Location = new System.Drawing.Point(16, 448);
            this.sessionsLabel.Name = "sessionsLabel";
            this.sessionsLabel.Size = new System.Drawing.Size(181, 22);
            this.sessionsLabel.TabIndex = 6;
            this.sessionsLabel.Text = "Sessions you chair at";
            // 
            // abstractsSaveButton
            // 
            this.abstractsSaveButton.Location = new System.Drawing.Point(235, 216);
            this.abstractsSaveButton.Name = "abstractsSaveButton";
            this.abstractsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.abstractsSaveButton.TabIndex = 8;
            this.abstractsSaveButton.Text = "Save";
            this.abstractsSaveButton.UseVisualStyleBackColor = true;
            this.abstractsSaveButton.Click += new System.EventHandler(this.abstractsSaveButton_Click);
            // 
            // papersSaveButton
            // 
            this.papersSaveButton.Location = new System.Drawing.Point(235, 431);
            this.papersSaveButton.Name = "papersSaveButton";
            this.papersSaveButton.Size = new System.Drawing.Size(75, 23);
            this.papersSaveButton.TabIndex = 9;
            this.papersSaveButton.Text = "Save";
            this.papersSaveButton.UseVisualStyleBackColor = true;
            this.papersSaveButton.Click += new System.EventHandler(this.papersSaveButton_Click);
            // 
            // createSessionButton
            // 
            this.createSessionButton.Location = new System.Drawing.Point(225, 652);
            this.createSessionButton.Name = "createSessionButton";
            this.createSessionButton.Size = new System.Drawing.Size(89, 23);
            this.createSessionButton.TabIndex = 10;
            this.createSessionButton.Text = "Create Session";
            this.createSessionButton.UseVisualStyleBackColor = true;
            // 
            // ReviewerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 689);
            this.Controls.Add(this.createSessionButton);
            this.Controls.Add(this.papersSaveButton);
            this.Controls.Add(this.abstractsSaveButton);
            this.Controls.Add(this.sessionsGridView);
            this.Controls.Add(this.sessionsLabel);
            this.Controls.Add(this.papersGridView);
            this.Controls.Add(this.papersLabel);
            this.Controls.Add(this.abstractGridView);
            this.Controls.Add(this.abstractsLabel);
            this.Name = "ReviewerWindow";
            this.Text = "Reviewer";
            ((System.ComponentModel.ISupportInitialize)(this.abstractGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.papersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label abstractsLabel;
        private System.Windows.Forms.DataGridView abstractGridView;
        private System.Windows.Forms.Label papersLabel;
        private System.Windows.Forms.DataGridView papersGridView;
        private System.Windows.Forms.DataGridView sessionsGridView;
        private System.Windows.Forms.Label sessionsLabel;
        private System.Windows.Forms.Button abstractsSaveButton;
        private System.Windows.Forms.Button papersSaveButton;
        private System.Windows.Forms.Button createSessionButton;
    }
}