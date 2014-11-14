using AFEI.Business;
using AFEI.Client.Font;
using AFEI.Client.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for changesLog.xaml
    /// </summary>
    public partial class ChangesHistory : MetroContentControl
    {
        private ChangesHistoryModel _viewmodel;
        private List<Models.History> _changesHistory;
        public ChangesHistory()
        {
            InitializeComponent();
        }
        public ChangesHistory(Object o)
        {
            InitializeComponent();
            HistoryBusiness historyBusiness = new HistoryBusiness();
            _changesHistory = (List<AFEI.Models.History>)o;
            _changesHistory = historyBusiness.GetList();
            _viewmodel = new ChangesHistoryModel(_changesHistory);
            DataContext = _viewmodel;
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ChangesHistoryDataGrid);
        }
    }
}
