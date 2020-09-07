namespace ConferenceManager.ConferenceManager.GUI
{
    partial class MainMenu
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
            this.ConferenceGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.CreateConferenceButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConferenceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ConferenceGrid
            // 
            this.ConferenceGrid.AllowUserToAddRows = false;
            this.ConferenceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConferenceGrid.Location = new System.Drawing.Point(47, 52);
            this.ConferenceGrid.Name = "ConferenceGrid";
            this.ConferenceGrid.Size = new System.Drawing.Size(575, 311);
            this.ConferenceGrid.TabIndex = 0;
            this.ConferenceGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConferenceGrid_CellContentDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Conferences list:";
            // 
            // CreateConferenceButton
            // 
            this.CreateConferenceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateConferenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateConferenceButton.Location = new System.Drawing.Point(102, 410);
            this.CreateConferenceButton.Name = "CreateConferenceButton";
            this.CreateConferenceButton.Size = new System.Drawing.Size(193, 28);
            this.CreateConferenceButton.TabIndex = 13;
            this.CreateConferenceButton.Text = "Create new conference";
            this.CreateConferenceButton.UseVisualStyleBackColor = true;
            this.CreateConferenceButton.Click += new System.EventHandler(this.CreateConferenceButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(369, 410);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(193, 28);
            this.RefreshButton.TabIndex = 14;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 469);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.CreateConferenceButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ConferenceGrid);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConferenceGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ConferenceGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CreateConferenceButton;
        private System.Windows.Forms.Button RefreshButton;
    }
}