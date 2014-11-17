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
                    stub.Provider = entity.Provider;
                    stub.Name = entity.Name;
                    stub.Quantity = entity.Quantity;
                    stub.Description = entity.Description;
                    AFEIEntities.SaveChanges();

                    var phase = AFEIEntities.Providers.Include("Provider");

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
                    response = AFEIentities.Products.ToList();
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
