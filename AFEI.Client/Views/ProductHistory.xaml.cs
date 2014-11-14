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
        private ProductHistoryModel _viewModel;
        private List<Models.Product> _clients;
        public ProductHistory()
        {
            InitializeComponent();
        }
        public ProductHistory(Object o)
        {
            InitializeComponent();
            ProductBusiness clientBusiness = new ProductBusiness();
            _clients = (List<AFEI.Models.Product>)o;
            _clients = clientBusiness.GetList();
            _viewModel = new ProductHistoryModel(_clients);
            DataContext = _viewModel;
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ProductHistoryDataGrid);
        }
    }
}
