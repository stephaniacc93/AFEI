using AFEI.Data;
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
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(History entity)
        {
            _unitOfWork.HistoryRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(History entity)
        {
            _unitOfWork.HistoryRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public History Read(int id)
        {
            return _unitOfWork.HistoryRepository.GetByID(id);
        }   

        public void Delete(int id)
        {
            _unitOfWork.HistoryRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<History> GetList()
        {
            return _unitOfWork.HistoryRepository.GetList();
        }
    }
}
