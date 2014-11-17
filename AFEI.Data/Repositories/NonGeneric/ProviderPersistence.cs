using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class ProviderPersistence
    {
        public Provider Create(Provider entity)
        {
            Provider response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    AFEIEntities.Providers.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Providers.Single(x => x.Id == entity.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public Provider Read(int entityId)
        {
            Provider response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Providers
                        .Include("Histories").Include("Products")
                        .Single(x => x.Id == entityId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public Provider Update(Provider entity)
        {
            Provider response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new Provider() { Id = entity.Id };
                    stub.FirstName = entity.FirstName;
                    stub.LastName = entity.LastName;
                    stub.Phone = entity.Phone;
                    stub.Company = entity.Company;
                    stub.Email = entity.Email;
                    AFEIEntities.SaveChanges();

                    var phase = AFEIEntities.Transactions .Include("Histories").Include("Products");

                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Providers.Single(x => x.Id == entity.Id);

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
                    var documentTypeToDelete = AFEIentities.Providers.Include("Histories").Include("Products").Single(x => x.Id == entityId);
                    AFEIentities.Providers.DeleteObject(documentTypeToDelete);
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

        public List<Provider> GetList()
        {
            List<Provider> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Providers.Include("Histories").Include("Products").ToList();
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
