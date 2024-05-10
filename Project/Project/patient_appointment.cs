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
        private void LoadDoctorDetails()
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

        private void patient_appointment_Load(object sender, EventArgs e)
        {
            LoadDoctorDetails();
        }
    }
}
