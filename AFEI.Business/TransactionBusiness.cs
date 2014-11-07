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
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(Transaction entity)
        {
            _unitOfWork.TransactionRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(Transaction entity)
        {
            _unitOfWork.TransactionRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public Transaction Read(int id)
        {
            return _unitOfWork.TransactionRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.TransactionRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<Transaction> GetList()
        {
            return _unitOfWork.TransactionRepository.GetList();
        }
    }
}
