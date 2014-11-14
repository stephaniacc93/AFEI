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
    class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private User _user;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public LoginModel(User user)
        {
            _user = user;   
        }
    }
}
