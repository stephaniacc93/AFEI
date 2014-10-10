using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFEI.Client.Views.Interfaces
{
    public interface IView
    {
        IView Previous { get; set; }
    }
}
