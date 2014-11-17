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
    class ProviderModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Models.Provider> _providers;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Models.Provider> Providers
        {
            get { return _providers; }
            set
            {
                _providers = value;
                OnPropertyChanged();
            }
        }

        public ProviderModel()
        {
        }
    }
}
