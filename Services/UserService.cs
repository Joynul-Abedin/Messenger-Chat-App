using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Entities;
using Interfaces;

namespace Services
{
    public class UserService
    {
        UserRepository userrepo;

        public UserService()
        {
            userrepo = new UserRepository();
        }

        public List<User> GetAllFriends()
        {
            return userrepo.GetAll();
        }

        public int searchByEmailAdd(string email)
        {
            return userrepo.searchByEmail(email);
        }

        public User SearchUserByName(string name)
        {
            return userrepo.SearchFriend(name);
        }

        public int? UpdatePassword(User user)
        {
            return userrepo.Update(user);
        }



    }
}
