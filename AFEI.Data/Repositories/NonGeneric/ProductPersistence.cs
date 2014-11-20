using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class ProductPersistence
    {
        ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
        
        public Product Create(Product entity)
        {
            Product response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    entity.Provider = AFEIEntities.Providers.First(x => x.Id == entity.Provider.Id);
                    AFEIEntities.Products.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Products.Single(x => x.Id == entity.Id);

                    ChangesLog changesLog = new ChangesLog()
                    {
                        Date = DateTime.Now,
                        Description = "Nuevo Producto",
                        Module = "Producto",
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

        public Product Read(int entityId)
        {
            Product response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Products
                        .Include("Provider")
                        .Single(x => x.Id == entityId);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public Product Update(Product entity)
        {
            Product response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new Product() { Id = entity.Id };
                    AFEIEntities.Products.Attach(stub);
                    AFEIEntities.Products.ApplyCurrentValues(entity);
                    stub.Quantity = entity.Quantity;
                    AFEIEntities.SaveChanges();


                    response = AFEIEntities.Products.Single(x => x.Id == entity.Id);
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
                    var documentTypeToDelete = AFEIentities.Products.Include("Provider").Single(x => x.Id == entityId);
                    AFEIentities.Products.DeleteObject(documentTypeToDelete);
                    AFEIentities.SaveChanges();
                    response = entityId;

                    ChangesLog changesLog = new ChangesLog()
                    {
                        Date = DateTime.Now,
                        Description = "Eliminacion Producto",
                        Module = "Producto",
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

        public List<Product> GetList()
        {
            List<Product> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Products.Include("Provider").ToList();
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
