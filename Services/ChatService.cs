using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Entities;

namespace Services
{
    public class ChatService
    {
        ChatRepository chatrepo;
        public ChatService()
        {
            chatrepo = new ChatRepository();
        }
        public List<Chats> getAllChat(int chatId)
        {
            return chatrepo.getAll(chatId);
        }
    }
}
