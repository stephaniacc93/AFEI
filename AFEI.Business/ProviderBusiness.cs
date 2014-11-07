using AFEI.Data;
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
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(Provider entity)
        {
            _unitOfWork.ProviderRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(Provider entity)
        {
            _unitOfWork.ProviderRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public Provider Read(int id)
        {
            return _unitOfWork.ProviderRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.ProviderRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<Provider> GetList()
        {
            return _unitOfWork.ProviderRepository.GetList();
        }
    }
}
