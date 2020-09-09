using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public class UserRepository : IRepository<User>, IDisposable
    {
        DataAccess dataAccess;
        public UserRepository()
        {
            dataAccess = new DataAccess();
        }
        public List<User> GetAll()
        {
            string sql = "SELECT * FROM Categories";
            SqlDataReader reader = dataAccess.ReadSqlData(sql);
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.Id = (int)reader["Id"];
                user.FirstName = reader["First_name"].ToString();
                users.Add(user);
            }
            return users;
        }

        public User SearchFriend(string name)
        {
            string sql = "SELECT * FROM Users WHERE First_Name='" + name + "'";
            SqlDataReader reader = dataAccess.ReadSqlData(sql);
            reader.Read();
            User user = new User();
            user.Id = (int)reader["Id"];
            user.FirstName = reader["First_Name"].ToString();
            user.LastName = reader["Last_Name"].ToString();
            return user;

        }
        public int searchByEmail(string email)
        {
            string sql = "SELECT * FROM Users WHERE Email='" + email + "'";
            SqlDataReader reader = dataAccess.ReadSqlData(sql);
            reader.Read();
            User user = new User();
            user.Id = (int)reader["Id"];
            user.FirstName = reader["First_Name"].ToString();
            user.LastName = reader["Last_Name"].ToString();
            return user.Id;
        }

        public int? Update(User user)
        {
            dataAccess = new DataAccess();
            string sql = "UPDATE Login_Credentials SET Password='" + user.Password + "' WHERE User_Id=" + user.Id;
            return dataAccess.ExecuteSqlQuery(sql);
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        int IRepository<User>.Update(User tentity)
        {
            throw new NotImplementedException();
        }
    }
}
