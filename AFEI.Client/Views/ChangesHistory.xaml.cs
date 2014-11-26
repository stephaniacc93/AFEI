using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
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
        private string _Filter;
        private ChangesHistoryModel _viewmodel;
        private List<Models.History> _changesHistory;
        ChangesLogBusiness ChangesLogBusiness = new ChangesLogBusiness();

        public ChangesHistory()
        {
            InitializeComponent();
            List<Models.ChangesLog> changesLogs = ChangesLogBusiness.GetList().OrderByDescending(x=>x.Date).ToList();
            _viewmodel = new ChangesHistoryModel();
            _viewmodel.ChangesLogs = changesLogs;
            DataContext = _viewmodel;
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ChangesHistoryDataGrid);
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ChangesHistoryDataGrid.ItemsSource);
            _Filter = SearchTextBox.Text.ToLower();
            view.Filter = new Predicate<object>(Filters);
        }

        private bool Filters(object obj)
        {
            Models.ChangesLog changesLog = obj as Models.ChangesLog;
            if (changesLog.Module.ToLower().Contains(_Filter))
                return true;
            else
                return false;
        }
    }
}
