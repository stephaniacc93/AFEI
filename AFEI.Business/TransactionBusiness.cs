using AFEI.Data;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    public class TransactionBusiness:IBusiness<Transaction>
    {
        TransactionBusiness transactionBusiness = new TransactionBusiness();
        public void Create(Transaction entity)
        {
            transactionBusiness.Create(entity);
        }

        public void Update(Transaction entity)
        {
            transactionBusiness.Update(entity);
        }

        public Transaction Read(int id)
        {
            return transactionBusiness.Read(id);
        }

        public void Delete(int id)
        {
            transactionBusiness.Delete(id);
        }

        public List<Transaction> GetList()
        {
            return transactionBusiness.GetList();
        }
    }
}
