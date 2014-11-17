using AFEI.Data;
using AFEI.Data.Repositories;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    public class UserBusiness:IBusiness<User>
    {
        private UserPersistence userPersistence = new UserPersistence();

        public void Create(User entity)
        {
            userPersistence.Create(entity);
        }

        public void Update(User entity)
        {
            userPersistence.Update(entity);
        }

        public User Read(int id)
        {
            return userPersistence.Read(id);
        }

        public void Delete(int id)
        {
            userPersistence.Delete(id);
        }


        public List<User> GetList()
        {
            return userPersistence.GetList();
        }
    }
}
