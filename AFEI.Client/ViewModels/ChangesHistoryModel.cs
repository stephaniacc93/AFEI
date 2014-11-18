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
        private List<ChangesLog> changesLogs;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<ChangesLog> ChangesLogs
        {
            get { return changesLogs; }
            set
            {
                changesLogs = value;
                OnPropertyChanged();
            }
        }

        public ChangesHistoryModel()
        {
        }
    }
}