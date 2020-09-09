using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RegistrationRepository
    {
        DataAccess dataAccess;
        public RegistrationRepository()
        {
            dataAccess = new DataAccess();
        }

        public int Register(string fname,string lname, string email,string dob, string phone,string region,string state,string religion, string username, string password)
        {
            string sql = "INSERT INTO Users(First_Name,Last_Name,Email,DOB,Phone,Region,State,Religion) VALUES('" + fname + "','"+lname+"','" + email + "','"+dob+"','" + phone + "','"+region+"','"+state+"','"+religion+"')";
            int? result = dataAccess.ExecuteSqlQuery(sql);
            if (result > 0)
            {
                dataAccess = new DataAccess();
                sql = "SELECT * FROM Users WHERE Email='" + email + "'";
                SqlDataReader reader = dataAccess.ReadSqlData(sql);
                reader.Read();
                int id = (int)reader["Id"];

                dataAccess = new DataAccess();
                sql = "INSERT INTO Login_Credentials(User_Name,Password,User_Id) VALUES('" + username + "','" + password + "'," + id + ")";
                result = dataAccess.ExecuteSqlQuery(sql);
                if (result > 0)
                {
                    return 1;
                }
                else { return 0; }
            }
            else { return 0; }
        }
    }
}
