using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Business
{
    public interface IBusiness <T>
    {
        void Create(T entity);
        void Update(T entity);
        T Read(int id);
        void Delete(int id);
        List<T> GetList();
    }
}
