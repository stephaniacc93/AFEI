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
    class FormClientModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Models.Client _client;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Models.Client Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged();
            }
        }

        public FormClientModel(Models.Client client)
        {
            _client = client;   
        }
    }
}
