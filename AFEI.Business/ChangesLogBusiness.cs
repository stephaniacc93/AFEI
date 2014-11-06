using AFEI.Data;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    class ChangesLogBusiness :IBusiness<ChangesLog>
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(ChangesLog entity)
        {
            _unitOfWork.ChangesLogRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(ChangesLog entity)
        {
            _unitOfWork.ChangesLogRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public ChangesLog Read(int id)
        {
            return _unitOfWork.ChangesLogRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.ChangesLogRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<ChangesLog> GetList()
        {
            return _unitOfWork.ChangesLogRepository.GetList();
        }
    }
}
