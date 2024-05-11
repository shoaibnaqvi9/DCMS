using BusinessLogicLayer;
using Project;
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
    public partial class doctor_login : Form
    {
        public doctor_login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string log = txtLogin.Text;
                BLL b = new BLL();
                bool loginSuccessful = b.Login_doctor(log);
                if (loginSuccessful)
                {
                    MessageBox.Show("LoggedIn Successfully");
                    this.Hide();
                    Form f = new doctor_login();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Doctor ID");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input format: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Dashboard();
            f.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}