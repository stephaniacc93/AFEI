using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories
{
    public class UserPersistence
    {
        public User Create(User entity)
        {
            User response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    AFEIEntities.Users.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Users.Single(x => x.Id == entity.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public User Read(int entityId)
        {
            User response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Users
                        .Include("ChangesLogs").Include("Histories").Include("Transactions")
                        .Single(x => x.Id == entityId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public User Update(User entity)
        {
            User response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new User() { Id = entity.Id };
                    stub.Firstname = entity.Firstname;
                    stub.Lastname = entity.Lastname;
                    stub.Phone = entity.Phone;
                    stub.Username = entity.Username; 
                    stub.Password = entity.Password;

                    AFEIEntities.SaveChanges();

                    var user =
                        AFEIEntities.Providers.Include("ChangesLogs").Include("Histories").Include("Transactions");

                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Users.Single(x => x.Id == entity.Id);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }


        public int Delete(int entityId)
        {
            int response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    var user = GetList().FirstOrDefault(x => x.Id == entityId);
                    var documentTypeToDelete = AFEIentities.Users.Include("ChangesLogs").Include("Histories").Include("Transactions").Single(x => x.Id == entityId);
                    AFEIentities.Users.DeleteObject(documentTypeToDelete);
                    AFEIentities.SaveChanges();
                    response = entityId;

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public List<User> GetList()
        {
            List<User> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Users.Include("ChangesLogs").Include("Histories").Include("Transactions").ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
    }
}
