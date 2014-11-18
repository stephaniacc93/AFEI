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

        //ESTA ES PARA EL CHANGES LOG

        private ChangesHistoryModel _viewmodel;
        private List<Models.History> _changesHistory;
        ChangesLogBusiness ChangesLogBusiness = new ChangesLogBusiness();

        public ChangesHistory()
        {
            InitializeComponent();
            List<Models.ChangesLog> changesLogs = ChangesLogBusiness.GetList();
            _viewmodel = new ChangesHistoryModel();
            _viewmodel.ChangesLogs = changesLogs;
            DataContext = _viewmodel;
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ChangesHistoryDataGrid);
        }
    }
}
