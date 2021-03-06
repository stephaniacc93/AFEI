﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AFEI.Models;

namespace AFEI.Client.ViewModels
{
    class ProductHistoryModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Models.History> histories;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Models.History> Histories
        {
            get { return histories; }
            set
            {
                histories = value;
                OnPropertyChanged();
            }
        }

        public ProductHistoryModel()
        {
        }
    }
}
