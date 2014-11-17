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
    public class PriceBusiness :IBusiness<Price>
    {
        PricePersistence pricePersistence = new PricePersistence();

        public void Create(Price entity)
        {
            pricePersistence.Create(entity);
        }

        public void Update(Price entity)
        {
            pricePersistence.Update(entity);
        }

        public Price Read(int id)
        {
            return pricePersistence.Read(id);
        }

        public void Delete(int id)
        {
            pricePersistence.Delete(id);
        }

        public List<Price> GetList()
        {
            return pricePersistence.GetList();
        }
    }
}
