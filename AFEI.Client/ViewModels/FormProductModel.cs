using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AFEI.Business;
using AFEI.Models;

namespace AFEI.Client.ViewModels
{
    public class FormProductModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Product _product;
        private List<Provider> _providers; 
        ProviderBusiness providerBusiness = new ProviderBusiness();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }

        public List<Provider> Providers
        {
            get { return providerBusiness.GetList(); }
            set
            {
                _providers = value;
                OnPropertyChanged();
            }
        }

        public FormProductModel(Product product)
        {
            _product = product;
        }
    }
}
