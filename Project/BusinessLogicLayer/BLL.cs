using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLogicLayer
{
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
        public void Registration(int Patientid, string Patientname, DateTime Patientdob, string Patientgender, string PatientCNIC, int Patientweight, string Patientcontact, string Patientaddress)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spinsertpatient_detail", Patientid, Patientname, Patientdob, Patientgender, PatientCNIC, Patientweight, Patientcontact, Patientaddress);
            d.ExecuteQuery();
            d.UnLoadSpParameters();
            d.CloseConnection();
        }
        public void Doctor_Registration(int Doctorid, string Doctorname, string Doctorspecialization, string Doctorcontact, string Doctoraddress)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spinsertdoctor_detail", Doctorid, Doctorname, Doctorspecialization, Doctorcontact, Doctoraddress);
            d.ExecuteQuery();
            d.UnLoadSpParameters();
            d.CloseConnection();
        }
        public void Admin_Registration(string adminname, string adminpassword, string adminrepass, string admincontact, string adminaddress)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spinsertadmin_detail", adminname, adminpassword, adminrepass, admincontact, adminaddress);
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
        public bool Login_admin(string name,string password)
        {
            DAL d = new DAL();
            d.OpenConnection();
            d.LoadSpParameters("_spselectadmin", name,password);
            SqlDataReader reader = d.GetDataReader();
            bool loginSuccessful = reader.HasRows;
            d.CloseConnection();
            return loginSuccessful;
        }
        // file:///D:/PAF%20KIET/Fifth%20Semester/OOAD/Project/SRS.pdf
    }
}