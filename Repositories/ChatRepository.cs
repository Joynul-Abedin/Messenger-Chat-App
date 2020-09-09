using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace Repositories
{
    public class ChatRepository
    {
        DataAccess data;


        public ChatRepository()
        {
            data = new DataAccess();
        }

        public List<Chats> getAll(int chatId)
        {
            string sql = "SELECT * FROM Categories";
            List<Chats> chats = new List<Chats>();
            SqlDataReader reader = data.ReadSqlData(sql);
            while (reader.Read())
            {
                Chats chat = new Chats();
                chat.ChatId = (int)reader["Id"];
                chat.ChatLine = reader["Chat_Line"].ToString();
                chat.User2 =(int) reader["User2"];
                chat.User1 = (int)reader["User1"];
                chats.Add(chat);
            }
            return chats;
        }


    }
}
