using AFEI.Data;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    public class ProductBusiness:IBusiness<Product>
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(Product entity)
        {
            _unitOfWork.ProductRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(Product entity)
        {
            _unitOfWork.ProductRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public Product Read(int id)
        {
            return _unitOfWork.ProductRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<Product> GetList()
        {
            return _unitOfWork.ProductRepository.GetList();
        }
    }
}
