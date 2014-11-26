using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using AFEI.Business;
using AFEI.Client.Font;
using AFEI.Client.ViewModels;
using AFEI.Models;
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
        ProductBusiness productBusiness = new ProductBusiness();
        ProviderBusiness providerBusiness= new ProviderBusiness();
        private string _Filter;

        public Inventory()
        {
            InitializeComponent();
            _viewModel = new InventoryModel();
            _viewModel.Products = productBusiness.GetList();
            DataContext = _viewModel;
        }

        public delegate void AddProductClickedHandler(object o);
        public event AddProductClickedHandler AddProductClicked;
        public void OnAddProductClicked(object o)
        {
            if (AddProductClicked != null)
            {
                AddProductClicked(o);
            }
        }

        public delegate void DeleteProductClickedHandler();
        public event DeleteProductClickedHandler DeleteProductClicked;
        public void OnDeleteProductClicked()
        {
            if (DeleteProductClicked != null)
            {
                DeleteProductClicked();
            }
        }

        private void AddProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddProductClicked(new Product());
        }


        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(InventoryDataGrid);
        }

        private void EntryButton_OnClick(object sender, RoutedEventArgs e)
        {
            var o = (Product)InventoryDataGrid.SelectedItem;
            Product p = productBusiness.Read(o.Id); 
            OnAddInventoryClicked(p);
        }

        public delegate void AddInventoryClickedHandler(object o);
        public event AddInventoryClickedHandler AddInventoryClicked;
        public void OnAddInventoryClicked(object o)
        {
            if (AddInventoryClicked != null)
            {
                AddInventoryClicked(o);
            }
        }

        public delegate void OutputInventoryClickedHandler(object o);
        public event OutputInventoryClickedHandler OutputInventoryClicked;
        public void OnOutputInventoryClicked(object o)
        {
            if (OutputInventoryClicked != null)
            {
                OutputInventoryClicked(o);
            }
        }

        private void OutputButton_OnClick(object sender, RoutedEventArgs e)
        {
            var o = (Product)InventoryDataGrid.SelectedItem;
            Product p = productBusiness.Read(o.Id);
            OnOutputInventoryClicked(p);
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(InventoryDataGrid.ItemsSource);
            _Filter = SearchTextBox.Text.ToLower();
            view.Filter = new Predicate<object>(Filters);
        }

        private bool Filters(object obj)
        {
            Models.Product product = obj as Models.Product;
            if (product.Name.ToLower().Contains(_Filter) || product.Provider.Company.ToLower().Contains(_Filter))
                return true;
            else
                return false;
        }
    }
}
