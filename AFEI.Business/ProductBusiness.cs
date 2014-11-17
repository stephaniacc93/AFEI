using AFEI.Data;
using AFEI.Data.Repositories.NonGeneric;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    public class ProductBusiness:IBusiness<Product>
    {
        private ProductPersistence productPersistence = new ProductPersistence();

        public void Create(Product entity)
        {
            productPersistence.Create(entity);
        }

        public void Update(Product entity)
        {
            productPersistence.Update(entity);
        }

        public Product Read(int id)
        {
            return productPersistence.Read(id);
        }

        public void Delete(int id)
        {
            productPersistence.Delete(id);
        }
   

        public List<Product> GetList()
        {
            return productPersistence.GetList();
        }
    }
}
