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
    public class ClientModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Models.Client> _clients;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Models.Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged();
            }
        }

        public ClientModel(List<Models.Client> clients)
        {
            _clients = clients;
        }
    }
}
