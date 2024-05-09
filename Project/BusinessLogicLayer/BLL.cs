using System;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public abstract class Registration
    {
        protected DAL d;

        public Registration()
        {
            d = new DAL();
        }

        public abstract void Register();

        protected void OpenAndCloseConnection(Action action)
        {
            d.OpenConnection();
            action();
            d.CloseConnection();
        }
    }
    public class AdminRegistration : Registration
    {
        public override void Register()
        {
            OpenAndCloseConnection(() =>
            {
                d.LoadSpParameters("_spinsertadmin_detail", Adminname, Adminpassword, Adminrepass, Admincontact,Adminaddress);
                d.ExecuteQuery();
                d.UnLoadSpParameters();
            });
        }

        public string Adminname { get; set; }
        public string Adminpassword { get; set; }
        public string Adminrepass { get; set; }
        public string Admincontact { get; set; }
        public string Adminaddress { get; set; }
    }

    public class PatientRegistration : Registration
    {
        public override void Register()
        {
            OpenAndCloseConnection(() =>
            {
                d.LoadSpParameters("_spinsertpatient_detail", Patientid, Patientname, Patientdob, Patientgender, PatientCNIC, Patientweight, Patientcontact, Patientaddress);
                d.ExecuteQuery();
                d.UnLoadSpParameters();
            });
        }

        public int Patientid { get; set; }
        public string Patientname { get; set; }
        public DateTime Patientdob { get; set; }
        public string Patientgender { get; set; }
        public string PatientCNIC { get; set; }
        public int Patientweight { get; set; }
        public string Patientcontact { get; set; }
        public string Patientaddress { get; set; }
    }

    public class DoctorRegistration : Registration
    {
        public override void Register()
        {
            OpenAndCloseConnection(() =>
            {
                d.LoadSpParameters("_spinsertdoctor_detail", Doctorid, Doctorname, Doctorspecialization, Doctorcontact, Doctoraddress);
                d.ExecuteQuery();
                d.UnLoadSpParameters();
            });
        }

        public int Doctorid { get; set; }
        public string Doctorname { get; set; }
        public string Doctorspecialization { get; set; }
        public string Doctorcontact { get; set; }
        public string Doctoraddress { get; set; }
    }

    public class BLL
    {
        public void Server_Connection(string server, string database, string db_username, string db_password)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spinsertserver", server, database, db_username, db_password);
            d.ExecuteQuery();
            d.UnLoadSpParameters();
            d.CloseConnection();
        }

        public bool Login_patient(string log)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spselectpatient", log);
            SqlDataReader reader = d.GetDataReader();
            bool loginSuccessful = reader.Read();
            d.CloseConnection();
            return loginSuccessful;
        }

        public bool Login_doctor(string log)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spselectdoctor", log);
            SqlDataReader reader = d.GetDataReader();
            bool loginSuccessful = reader.Read();
            d.CloseConnection();
            return loginSuccessful;
        }

        public bool Login_admin(string name, string password)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spselectadmin", name, password);
            SqlDataReader reader = d.GetDataReader();
            bool loginSuccessful = reader.HasRows;
            d.CloseConnection();
            return loginSuccessful;
        }
    }
}