using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Client.ViewModels
{
    class InventoryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Models.Product> _products;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Models.Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public InventoryModel(List<Models.Product> products)
        {
            _products = products;
        }
    }
}
