using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity SearchFriend(string name);
        int Update(TEntity tentity);

       // List<TEntity> GetChats();
    }
}
