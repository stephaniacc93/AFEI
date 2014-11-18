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
    public class MenuViewModel
    {
           public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<ChangesLog> changesLogs;

        public List<ChangesLog> ChangesLogs
        {
            get { return changesLogs; }
            set
            {
                changesLogs = value;
                OnPropertyChanged();
            }
        } 
        
        private List<History> histories;

        public List<History> Histories
        {
            get { return histories; }
            set
            {
                histories = value;
                OnPropertyChanged();
            }
        }

        public MenuViewModel()
        {
        }
    }
}
