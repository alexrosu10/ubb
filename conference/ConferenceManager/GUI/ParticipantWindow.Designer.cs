namespace ConferenceManager.ConferenceManager.GUI
{
    partial class ParticipantWindow
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
            this.abstractsGridView = new System.Windows.Forms.DataGridView();
            this.sessionsLabel = new System.Windows.Forms.Label();
            this.sessionsGridView = new System.Windows.Forms.DataGridView();
            this.refreshAllButton = new System.Windows.Forms.Button();
            this.refreshAbstractsButton = new System.Windows.Forms.Button();
            this.refreshSessionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.abstractsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // abstractsLabel
            // 
            this.abstractsLabel.AutoSize = true;
            this.abstractsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.abstractsLabel.Location = new System.Drawing.Point(13, 13);
            this.abstractsLabel.Name = "abstractsLabel";
            this.abstractsLabel.Size = new System.Drawing.Size(85, 22);
            this.abstractsLabel.TabIndex = 0;
            this.abstractsLabel.Text = "Abstracts";
            // 
            // abstractsGridView
            // 
            this.abstractsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.abstractsGridView.Location = new System.Drawing.Point(17, 51);
            this.abstractsGridView.Name = "abstractsGridView";
            this.abstractsGridView.Size = new System.Drawing.Size(520, 235);
            this.abstractsGridView.TabIndex = 3;
            // 
            // sessionsLabel
            // 
            this.sessionsLabel.AutoSize = true;
            this.sessionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.sessionsLabel.Location = new System.Drawing.Point(14, 313);
            this.sessionsLabel.Name = "sessionsLabel";
            this.sessionsLabel.Size = new System.Drawing.Size(83, 22);
            this.sessionsLabel.TabIndex = 4;
            this.sessionsLabel.Text = "Sessions";
            // 
            // sessionsGridView
            // 
            this.sessionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionsGridView.Location = new System.Drawing.Point(18, 356);
            this.sessionsGridView.Name = "sessionsGridView";
            this.sessionsGridView.Size = new System.Drawing.Size(520, 235);
            this.sessionsGridView.TabIndex = 5;
            // 
            // refreshAllButton
            // 
            this.refreshAllButton.Location = new System.Drawing.Point(190, 313);
            this.refreshAllButton.Name = "refreshAllButton";
            this.refreshAllButton.Size = new System.Drawing.Size(75, 23);
            this.refreshAllButton.TabIndex = 6;
            this.refreshAllButton.Text = "Refresh All";
            this.refreshAllButton.UseVisualStyleBackColor = true;
            this.refreshAllButton.Click += new System.EventHandler(this.refreshAllButton_Click);
            // 
            // refreshAbstractsButton
            // 
            this.refreshAbstractsButton.Location = new System.Drawing.Point(271, 313);
            this.refreshAbstractsButton.Name = "refreshAbstractsButton";
            this.refreshAbstractsButton.Size = new System.Drawing.Size(107, 23);
            this.refreshAbstractsButton.TabIndex = 7;
            this.refreshAbstractsButton.Text = "Refresh Abstracts";
            this.refreshAbstractsButton.UseVisualStyleBackColor = true;
            this.refreshAbstractsButton.Click += new System.EventHandler(this.refreshAbstractsButton_Click);
            // 
            // refreshSessionsButton
            // 
            this.refreshSessionsButton.Location = new System.Drawing.Point(384, 313);
            this.refreshSessionsButton.Name = "refreshSessionsButton";
            this.refreshSessionsButton.Size = new System.Drawing.Size(107, 23);
            this.refreshSessionsButton.TabIndex = 8;
            this.refreshSessionsButton.Text = "Refresh Sessions";
            this.refreshSessionsButton.UseVisualStyleBackColor = true;
            this.refreshSessionsButton.Click += new System.EventHandler(this.refreshSessionsButton_Click);
            // 
            // ParticipantWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.refreshSessionsButton);
            this.Controls.Add(this.refreshAbstractsButton);
            this.Controls.Add(this.refreshAllButton);
            this.Controls.Add(this.sessionsGridView);
            this.Controls.Add(this.sessionsLabel);
            this.Controls.Add(this.abstractsGridView);
            this.Controls.Add(this.abstractsLabel);
            this.Name = "ParticipantWindow";
            this.Text = "ParticipantWindow";
            ((System.ComponentModel.ISupportInitialize)(this.abstractsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label abstractsLabel;
        private System.Windows.Forms.DataGridView abstractsGridView;
        private System.Windows.Forms.Label sessionsLabel;
        private System.Windows.Forms.DataGridView sessionsGridView;
        private System.Windows.Forms.Button refreshAllButton;
        private System.Windows.Forms.Button refreshAbstractsButton;
        private System.Windows.Forms.Button refreshSessionsButton;
    }
}