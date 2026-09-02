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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm();
            reportForm.Show();
            this.Hide();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be available in Part 2.", "Coming Soon",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be available in the final PoE.", "Coming Soon",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}