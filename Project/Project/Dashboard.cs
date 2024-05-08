using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnrgdoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new doctor_registration();
            f.Show();
        }

        private void btnlgdoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new doctor_login();
            f.Show();
        }

        private void btnrgpat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new patient_registration();
            f.Show();
        }

        private void btnlgpat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new patient_login();
            f.Show();
        }

        private void btnrgadm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new admin_registration();
            f.Show();
        }

        private void btnlgadm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new admin_login();
            f.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}