using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace Repositories
{
    public class DataAccess : IDisposable
    {
        private SqlConnection connection;

        public DataAccess()
        {
            connection = new SqlConnection("Data Source=.\\SHOKAL1;Initial Catalog=Chat App;Integrated Security=True");
        }

        public SqlDataReader ReadSqlData(string query)
        {
            try
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = this.connection;
                SqlDataReader data = command.ExecuteReader();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + query);
                return null;
            }
        }

        public int? ExecuteSqlQuery(string query)
        {
            try
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = this.connection;
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + query);
                return null;
            }
        }

        public string ExecuteSqlScalar(string query)
        {
            try
            {
                this.connection.Open();
                SqlCommand command = new SqlCommand(query, this.connection);
                return command.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + query);
                return null;
            }
        }

        void IDisposable.Dispose()
        {
            try
            {
                this.CloseConnection();
            }
            catch { }
        }

        public void Dispose()
        {
            try
            {
                this.CloseConnection();
            }
            catch { }
        }

        public void CloseConnection()
        {
            this.connection.Close();
        }

        public static DataAccess Instance
        {
            get { return new DataAccess(); }
        }

    }
}


