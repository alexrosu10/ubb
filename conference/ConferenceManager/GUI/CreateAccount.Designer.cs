namespace ConferenceManager
{
    partial class CreateAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.AccountTypeLabel = new System.Windows.Forms.Label();
            this.accountTypeCombo = new System.Windows.Forms.ComboBox();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.AffiliationTextBox = new System.Windows.Forms.TextBox();
            this.AffiliationLabel = new System.Windows.Forms.Label();
            this.WebPageTextBox = new System.Windows.Forms.TextBox();
            this.WebPageLabel = new System.Windows.Forms.Label();
            this.RetypeTextBox = new System.Windows.Forms.TextBox();
            this.RetypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create a new account";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(14, 81);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(77, 17);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(14, 110);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(73, 17);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // AccountTypeLabel
            // 
            this.AccountTypeLabel.AutoSize = true;
            this.AccountTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountTypeLabel.Location = new System.Drawing.Point(14, 168);
            this.AccountTypeLabel.Name = "AccountTypeLabel";
            this.AccountTypeLabel.Size = new System.Drawing.Size(94, 17);
            this.AccountTypeLabel.TabIndex = 5;
            this.AccountTypeLabel.Text = "Account type:";
            // 
            // accountTypeCombo
            // 
            this.accountTypeCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTypeCombo.FormattingEnabled = true;
            this.accountTypeCombo.Items.AddRange(new object[] {
            "Program Committee Member",
            "Author",
            "Participant"});
            this.accountTypeCombo.Location = new System.Drawing.Point(141, 168);
            this.accountTypeCombo.Name = "accountTypeCombo";
            this.accountTypeCombo.Size = new System.Drawing.Size(193, 23);
            this.accountTypeCombo.TabIndex = 6;
            this.accountTypeCombo.SelectedIndexChanged += new System.EventHandler(this.AccountTypeCombo_SelectedIndexChanged);
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccountButton.Location = new System.Drawing.Point(5, 210);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(110, 23);
            this.CreateAccountButton.TabIndex = 7;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.UseVisualStyleBackColor = true;
            this.CreateAccountButton.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(141, 110);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(193, 23);
            this.PasswordTextBox.TabIndex = 8;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextBox.Location = new System.Drawing.Point(141, 81);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(193, 23);
            this.UsernameTextBox.TabIndex = 9;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTextBox.Location = new System.Drawing.Point(586, 81);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(193, 23);
            this.FirstNameTextBox.TabIndex = 11;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(443, 81);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(80, 17);
            this.FirstNameLabel.TabIndex = 10;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameTextBox.Location = new System.Drawing.Point(586, 110);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(193, 23);
            this.LastNameTextBox.TabIndex = 13;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(443, 110);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(80, 17);
            this.LastNameLabel.TabIndex = 12;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(586, 168);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(193, 23);
            this.EmailTextBox.TabIndex = 17;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(443, 168);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(46, 17);
            this.EmailLabel.TabIndex = 16;
            this.EmailLabel.Text = "Email:";
            // 
            // AffiliationTextBox
            // 
            this.AffiliationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AffiliationTextBox.Location = new System.Drawing.Point(586, 139);
            this.AffiliationTextBox.Name = "AffiliationTextBox";
            this.AffiliationTextBox.Size = new System.Drawing.Size(193, 23);
            this.AffiliationTextBox.TabIndex = 15;
            // 
            // AffiliationLabel
            // 
            this.AffiliationLabel.AutoSize = true;
            this.AffiliationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AffiliationLabel.Location = new System.Drawing.Point(443, 139);
            this.AffiliationLabel.Name = "AffiliationLabel";
            this.AffiliationLabel.Size = new System.Drawing.Size(69, 17);
            this.AffiliationLabel.TabIndex = 14;
            this.AffiliationLabel.Text = "Affiliation:";
            // 
            // WebPageTextBox
            // 
            this.WebPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebPageTextBox.Location = new System.Drawing.Point(586, 197);
            this.WebPageTextBox.Name = "WebPageTextBox";
            this.WebPageTextBox.Size = new System.Drawing.Size(193, 23);
            this.WebPageTextBox.TabIndex = 19;
            // 
            // WebPageLabel
            // 
            this.WebPageLabel.AutoSize = true;
            this.WebPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebPageLabel.Location = new System.Drawing.Point(443, 197);
            this.WebPageLabel.Name = "WebPageLabel";
            this.WebPageLabel.Size = new System.Drawing.Size(138, 17);
            this.WebPageLabel.TabIndex = 18;
            this.WebPageLabel.Text = "Personal Web Page:";
            // 
            // RetypeTextBox
            // 
            this.RetypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetypeTextBox.Location = new System.Drawing.Point(141, 139);
            this.RetypeTextBox.Name = "RetypeTextBox";
            this.RetypeTextBox.PasswordChar = '*';
            this.RetypeTextBox.Size = new System.Drawing.Size(193, 23);
            this.RetypeTextBox.TabIndex = 21;
            this.RetypeTextBox.UseSystemPasswordChar = true;
            // 
            // RetypeLabel
            // 
            this.RetypeLabel.AutoSize = true;
            this.RetypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetypeLabel.Location = new System.Drawing.Point(14, 139);
            this.RetypeLabel.Name = "RetypeLabel";
            this.RetypeLabel.Size = new System.Drawing.Size(122, 17);
            this.RetypeLabel.TabIndex = 20;
            this.RetypeLabel.Text = "Retype Password:";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RetypeTextBox);
            this.Controls.Add(this.RetypeLabel);
            this.Controls.Add(this.WebPageTextBox);
            this.Controls.Add(this.WebPageLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.AffiliationTextBox);
            this.Controls.Add(this.AffiliationLabel);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.CreateAccountButton);
            this.Controls.Add(this.accountTypeCombo);
            this.Controls.Add(this.AccountTypeLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.label1);
            this.Name = "CreateAccount";
            this.Text = "CreateAccount";
            this.Load += new System.EventHandler(this.CreateAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label AccountTypeLabel;
        private System.Windows.Forms.ComboBox accountTypeCombo;
        private System.Windows.Forms.Button CreateAccountButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox AffiliationTextBox;
        private System.Windows.Forms.Label AffiliationLabel;
        private System.Windows.Forms.TextBox WebPageTextBox;
        private System.Windows.Forms.Label WebPageLabel;
        private System.Windows.Forms.TextBox RetypeTextBox;
        private System.Windows.Forms.Label RetypeLabel;
    }
}