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
    public class ProviderBusiness:IBusiness<Provider>
    {
        ProviderPersistence providerPersistence = new ProviderPersistence();

        public void Create(Provider entity)
        {
            providerPersistence.Create(entity);
        }

        public void Update(Provider entity)
        {
            providerPersistence.Update(entity);
        }

        public Provider Read(int id)
        {
            return providerPersistence.Read(id);
        }

        public void Delete(int id)
        {
            providerPersistence.Delete(id);
        }

        public List<Provider> GetList()
        {
            return providerPersistence.GetList();
        }
    }
}
