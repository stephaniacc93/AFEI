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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : MetroContentControl
    {
        private InventoryModel _viewModel;
        private List<Models.Product> _inventory;
        public Inventory()
        {
            InitializeComponent();
        }

        public Inventory(Object o)
        {
            InitializeComponent();
            ProductBusiness clientBusiness = new ProductBusiness();
            _inventory = (List<AFEI.Models.Product>)o;
            _inventory = clientBusiness.GetList();
            _viewModel = new InventoryModel(_inventory);
            DataContext = _viewModel;
        }

        public delegate void AddProductClickedHandler();
        public event AddProductClickedHandler AddProductClicked;
        public void OnAddProductClicked()
        {
            if (AddProductClicked != null)
            {
                AddProductClicked();
            }
        }

        private void AddProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddProductClicked();
        }

        private void DeleteProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(InventoryDataGrid);
        }
    }
}
