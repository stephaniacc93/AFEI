using System;
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

        private ProductHistoryModel _viewModel;

        public ProductHistory()
        {
            InitializeComponent();
            HistoryBusiness historyBusiness = new HistoryBusiness();
            List<Models.History> histories = historyBusiness.GetList();
            _viewModel = new ProductHistoryModel();
            _viewModel.Histories = histories;
            DataContext = _viewModel;
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ProductHistoryDataGrid);
        }
    }
}
