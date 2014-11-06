using AFEI.Data;
using AFEI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Business
{
    public class ClientBusiness : IBusiness<Client>
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public void Create(Client entity)
        {   
            _unitOfWork.ClientRepository.Insert(entity);
            _unitOfWork.CommitChanges();
        }

        public void Update(Client entity)
        {
            _unitOfWork.ClientRepository.Update(entity);
            _unitOfWork.CommitChanges();
        }

        public Client Read(int id)
        {
            return _unitOfWork.ClientRepository.GetByID(id);
        }

        public void Delete(int id)
        {
            _unitOfWork.ClientRepository.Delete(id);
            _unitOfWork.CommitChanges();
        }

        public List<Client> GetList()
        {
            return _unitOfWork.ClientRepository.GetList();
        }
    }
}
