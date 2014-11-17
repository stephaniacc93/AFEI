using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Data.Repositories.NonGeneric
{
    public class PricePersistence
    {
        ProductPersistence productPersistence = new ProductPersistence();

        public Price Create(Price entity)
        {
            Price response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    AFEIEntities.Prices.AddObject(entity);
                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Prices.Single(x => x.Id == entity.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public Price Read(int entityId)
        {
            Price response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    response = AFEIEntities.Prices
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

        public Price Update(Price entity)
        {
            Price response;
            try
            {
                using (var AFEIEntities = new AFEIEntities())
                {
                    var stub = new Price() { Id = entity.Id };
                    stub.Price1 = entity.Price1;
                    stub.Date = entity.Date;
                    stub.Products = entity.Products;
                    AFEIEntities.SaveChanges();

                    var price = AFEIEntities.Prices.Include("Products");

                    AFEIEntities.SaveChanges();
                    response = AFEIEntities.Prices.Single(x => x.Id == entity.Id);

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
                    var price = GetList().FirstOrDefault(x => x.Id == entityId);
                    var documentTypeToDelete = AFEIentities.Prices.Include("Products").Single(x => x.Id == entityId);
                    AFEIentities.Prices.DeleteObject(documentTypeToDelete);
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

        public List<Price> GetList()
        {
            List<Price> response;
            try
            {
                using (var AFEIentities = new AFEIEntities())
                {
                    response = AFEIentities.Prices.Include("Products").ToList();
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
