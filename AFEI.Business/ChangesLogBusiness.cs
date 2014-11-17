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
    public class ChangesLogBusiness :IBusiness<ChangesLog>
    {

        public void Create(ChangesLog entity)
        {
            ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
            changesLogPersistence.Create(entity);
        }

        public void Update(ChangesLog entity)
        {
            ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
            changesLogPersistence.Update(entity);
        }

        public ChangesLog Read(int id)
        {
            ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
            return changesLogPersistence.Read(id);
        }

        public void Delete(int id)
        {
            ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
            changesLogPersistence.Delete(id);
        }

        public List<ChangesLog> GetList()
        {
            ChangesLogPersistence changesLogPersistence = new ChangesLogPersistence();
            return changesLogPersistence.GetList();
        }
    }
}
