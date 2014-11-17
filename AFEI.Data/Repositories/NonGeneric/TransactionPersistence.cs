using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class TransactionPersistence
    {
        public Transaction Create(Transaction entity)
        {
            Transaction response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    entity.User = AFEIEntities.Users.First(x => x.Id == entity.User.Id);
                    AFEIEntities.Transactions.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Transactions.Single(x => x.Id == entity.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public Transaction Read(int entityId)
        {
            Transaction response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Transactions
                        .Include("User").Include("Products").Include("Histories")
                        .Single(x => x.Id == entityId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public Transaction Update(Transaction entity)
        {
            Transaction response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new Transaction() { Id = entity.Id };
                    stub.Total = entity.Total;
                    stub.Type = entity.Type;
                    stub.Date = entity.Date;
                    stub.User = entity.User;
                    AFEIEntities.SaveChanges();

                    var phase = AFEIEntities.Transactions.Include("User").Include("Products").Include("Histories");

                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Transactions.Single(x => x.Id == entity.Id);

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
                    var phase = GetList().FirstOrDefault(x => x.Id == entityId);
                    var documentTypeToDelete = AFEIentities.Transactions.Include("User").Include("Products").Include("Histories").Include("Provider").Single(x => x.Id == entityId);
                    AFEIentities.Transactions.DeleteObject(documentTypeToDelete);
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

        public List<Transaction> GetList()
        {
            List<Transaction> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Transactions.Include("User").Include("Products").Include("Histories").Include("Provider").ToList();
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
