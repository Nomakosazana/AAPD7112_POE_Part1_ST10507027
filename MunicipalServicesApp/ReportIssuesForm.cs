using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        private string attachedFileName = "";

        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Image or Document";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Files|*.pdf|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                attachedFileName = openFileDialog.FileName;
                lblFileName.Text = System.IO.Path.GetFileName(attachedFileName);
                lblFileName.ForeColor = Color.Green;

                // Increase progress bar for attaching file
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value = Math.Min(progressBar1.Value + 20, 100);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtxtDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtxtDescription.Focus();
                return;
            }

            // Create new issue report
            IssueReport newIssue = new IssueReport
            {
                Location = txtLocation.Text.Trim(),
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtxtDescription.Text.Trim(),
                AttachedFilePath = attachedFileName,
                ReportDate = DateTime.Now
            };

            // Add to the list (data structure)
            DataManager.ReportedIssues.Add(newIssue);

            // Success message
            MessageBox.Show("Issue reported successfully!\n\nThank you for helping improve our municipality.\nYour report has been submitted.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form
            txtLocation.Clear();
            rtxtDescription.Clear();
            cmbCategory.SelectedIndex = -1;
            lblFileName.Text = "No file attached";
            lblFileName.ForeColor = Color.Blue;
            attachedFileName = "";
            progressBar1.Value = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainMenu = new Form1();
            mainMenu.Show();
            this.Close();
        }

        // Engagement Feature: Update progress bar as user types
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void rtxtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                progress += 25;

            if (cmbCategory.SelectedIndex != -1)
                progress += 25;

            if (!string.IsNullOrWhiteSpace(rtxtDescription.Text))
                progress += 25;

            if (!string.IsNullOrWhiteSpace(attachedFileName))
                progress += 25;

            progressBar1.Value = progress;

            // Add encouraging message based on progress
            if (progress == 100)
            {
                this.Text = "Report an Issue - Ready to Submit!";
            }
            else if (progress >= 50)
            {
                this.Text = "Report an Issue - Almost there!";
            }
            else
            {
                this.Text = "Report an Issue";
            }
        }
    }
}