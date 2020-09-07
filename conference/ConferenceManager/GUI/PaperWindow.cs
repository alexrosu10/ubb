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
    public partial class PaperWindow : Form
    {
        private Paper pap;
        private Controller.Controller ctrl;
        public PaperWindow(Paper pap,Controller.Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.pap = pap;
            this.nameLabel.Text = pap.Name;
            if(this.pap.Content == "")
            {
                this.uploadLabel.Text = "Uploaded";
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!openFileDialog.FileName.Contains(".pdf"))
                {
                    MessageBox.Show("Please only upload pdfs!", "Error!");
                    return;
                }
                pap.Content = openFileDialog.FileName;
                this.nameLabel.Text = "Uploaded";
                ctrl.repository.SaveChanges();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if(pap.Content != "")
            {
                System.Diagnostics.Process.Start(pap.Content);
            }
            else
            {
                MessageBox.Show("No file uploaded yet!", "Error!");
            }
        }
    }
}
