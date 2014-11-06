using AFEI.Data;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    class PriceBusiness :IBusiness<Price>
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(Price entity)
        {
            _unitOfWork.PriceRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(Price entity)
        {
            _unitOfWork.PriceRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public Price Read(int id)
        {
            return _unitOfWork.PriceRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.PriceRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<Price> GetList()
        {
            return _unitOfWork.PriceRepository.GetList();
        }
    }
}
