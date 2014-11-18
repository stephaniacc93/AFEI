using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class ClientPersistence
    {
        ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
        
       public Client Create(Client entity)
        {
            Client response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    AFEIEntities.Clients.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Clients.Single(x => x.Id == entity.Id);

                    ChangesLog changesLog = new ChangesLog()
                    {
                        Date =  DateTime.Now,
                        Description = "Nuevo Cliente",
                        Module = "Client",
                        User =  LogInfo.LoggedUser
                    };
                    changesLogPersistence.Create(changesLog);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public Client Read(int entityId)
        {
            Client response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Clients
                        .Include("Products")
                        .Single(x => x.Id == entityId);

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public Client Update(Client entity)
        {
            Client response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new Client() { Id = entity.Id };
                    //stub.FirstName = entity.FirstName;
                    //stub.LastName = entity.LastName;
                    //stub.Phone = entity.Phone;
                    //stub.Products = entity.Products;
                    AFEIEntities.Clients.Attach(stub);
                    AFEIEntities.Clients.ApplyCurrentValues(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Clients.Single(x => x.Id == entity.Id);

                    ChangesLog changesLog = new ChangesLog()
                    {
                        Date = DateTime.Now,
                        Description = "Actualizacion Cliente",
                        Module = "Client",
                        User = LogInfo.LoggedUser
                    };
                    changesLogPersistence.Create(changesLog);

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
                    var client = GetList().FirstOrDefault(x => x.Id == entityId);
                    var documentTypeToDelete = AFEIentities.Clients
                        .Include("Products").Single(x => x.Id == entityId);
                    AFEIentities.Clients.DeleteObject(documentTypeToDelete);
                    AFEIentities.SaveChanges();
                    response = entityId;

                    ChangesLog changesLog = new ChangesLog()
                    {
                        Date = DateTime.Now,
                        Description = "Eliminacion Cliente",
                        Module = "Client",
                        User = LogInfo.LoggedUser
                    };
                    changesLogPersistence.Create(changesLog);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public List<Client> GetList()
        {
            List<Client> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Clients
                        .Include("Products").ToList();
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
