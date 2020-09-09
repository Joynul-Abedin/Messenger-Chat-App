using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class LogInRepository
    {
        DataAccess dataAccess;
        public LogInRepository()
        {
            dataAccess = new DataAccess();
        }

        public int Validation(string username, string password)
        {
            string sql = "SELECT * FROM Login_Credentials WHERE User_Name='" + username + "' AND Password='" + password + "'";
            SqlDataReader reader = dataAccess.ReadSqlData(sql);

            if (reader.Read())
            {
                string userName = reader["User_Name"].ToString();
                string pass = reader["Password"].ToString();
                if (userName == username && password == pass)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
