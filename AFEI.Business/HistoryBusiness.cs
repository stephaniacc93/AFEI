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
    public class HistoryBusiness : IBusiness<History>
    {
        HistoryPersistence historyPersistence = new HistoryPersistence();

        public void Create(History entity)
        {
            historyPersistence.Create(entity);
        }

        public void Update(History entity)
        {
            historyPersistence.Update(entity);
        }

        public History Read(int id)
        {
            return historyPersistence.Read(id);
        }   

        public void Delete(int id)
        {
            historyPersistence.Delete(id);
        }

        public List<History> GetList()
        {
            return historyPersistence.GetList();
        }
    }
}
