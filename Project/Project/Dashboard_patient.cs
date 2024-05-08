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
    public partial class Dashboard_patient : Form
    {
        public Dashboard_patient()
        {
            InitializeComponent();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
        private void Logout()
        {
            this.Hide();
            patient_registration patientRegistrationForm = new patient_registration();
            patientRegistrationForm.Show();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new patient_appointment();
            f.Show();
        }
    }
}