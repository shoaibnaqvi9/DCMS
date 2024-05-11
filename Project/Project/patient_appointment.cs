using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
namespace Project
{
    public partial class patient_appointment : Form
    {
        private BLL bll = new BLL();
        Random random = new Random();
        public patient_appointment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Dashboard_patient();
            f.Show();
        }
        private void patient_appointment_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable doctorDetails = bll.GetDoctorDetails();
                dgvDoctor.DataSource = doctorDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvDoctor.ClearSelection();
                dgvDoctor.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dtpAppoint_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpAppoint.Value;
            DateTime currentDate = DateTime.Today;
            if (selectedDate < currentDate)
            {
                MessageBox.Show("Please select a date that is not in the past.");
                dtpAppoint.Value = currentDate;
            }
        }

        private void btnAppoint_Click(object sender, EventArgs e)
        {
            int appointmentId = random.Next(100000);
        }
    } 
}