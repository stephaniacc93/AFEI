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
    public class ChangesHistoryModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<History> _changesHistory;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<History> ChangesHistory
        {
            get { return _changesHistory; }
            set
            {
                _changesHistory = value;
                OnPropertyChanged();
            }
        }

        public ChangesHistoryModel(List<History> changesHistory)
        {
            _changesHistory = changesHistory;   
        }
    }
}