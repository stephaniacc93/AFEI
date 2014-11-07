using AFEI.Data;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    public class UserBusiness : IBusiness<User>
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(User entity)
        {
            _unitOfWork.UserRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(User entity)
        {
            _unitOfWork.UserRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public User Read(int id)
        {
            return _unitOfWork.UserRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<User> GetList()
        {
            return _unitOfWork.UserRepository.GetList();
        }
    }
}
