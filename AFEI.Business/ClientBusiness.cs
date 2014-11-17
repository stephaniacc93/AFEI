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
    public class ClientBusiness : IBusiness<Client>
    {
        ClientPersistence clientPersistence = new ClientPersistence();

        public void Create(Client entity)
        {
            clientPersistence.Create(entity);
        }

        public void Update(Client entity)
        {
            clientPersistence.Update(entity);
        }

        public Client Read(int id)
        {
            return clientPersistence.Read(id);
        }

        public void Delete(int id)
        {
            clientPersistence.Delete(id);
        }

        public List<Client> GetList()
        {
            return clientPersistence.GetList();
        }
    }
}
