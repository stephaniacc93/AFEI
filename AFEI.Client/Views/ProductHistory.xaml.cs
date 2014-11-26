using System;
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
    /// Interaction logic for ProductHistory.xaml
    /// </summary>
    public partial class ProductHistory : MetroContentControl
    {

        //AQUI SE DESPLEGAN LAS HISTORIES
        private string _Filter;
        private ProductHistoryModel _viewModel;

        public ProductHistory()
        {
            InitializeComponent();
            HistoryBusiness historyBusiness = new HistoryBusiness();
            List<Models.History> histories = historyBusiness.GetList().OrderByDescending(x=>x.Date).ToList();
            _viewModel = new ProductHistoryModel();
            _viewModel.Histories = histories;
            DataContext = _viewModel;
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ProductHistoryDataGrid);
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ProductHistoryDataGrid.ItemsSource);
            _Filter = SearchTextBox.Text.ToLower();
            view.Filter = new Predicate<object>(Filters);
        }

        private bool Filters(object obj)
        {
            Models.History history = obj as Models.History;
            if (history.TransactionType.ToLower().Contains(_Filter) || history.TransactionAmount.ToString().ToLower().Contains(_Filter) || history.Provider.Company.ToLower().Contains(_Filter) || history.Date.ToString("d").ToLower().Contains(_Filter))
                return true;
            else
                return false;
        }
    }
}
