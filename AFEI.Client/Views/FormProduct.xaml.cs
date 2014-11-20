using System;
using AFEI.Business;
using AFEI.Client.ViewModels;
using AFEI.Models;
using MahApps.Metro.Controls;
using System.Windows;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for FormProduct.xaml
    /// </summary>
    public partial class FormProduct : MetroContentControl
    {
        private FormProductModel _viewModel;
        private Models.Product _product;
        ProductBusiness productBusiness = new ProductBusiness();
        ChangesLogBusiness changesLogBusiness = new ChangesLogBusiness();

        public FormProduct()
        {
                
        }
        public FormProduct(object o)
        {
            InitializeComponent();
            ProductBusiness productBusiness = new ProductBusiness();
            _product = (AFEI.Models.Product)o;
            if (_product.Id != 0)
                _product = productBusiness.Read(_product.Id);
            _viewModel = new FormProductModel(_product);
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
            if (_viewModel.Product.Id != 0)
            {
                productBusiness.Update(_viewModel.Product);
                ChangesLog changesLog = new ChangesLog()
                {
                    Date = DateTime.Now,
                    Description = "Actualizacion de Producto",
                    Module = "Producto",
                    User = LogInfo.LoggedUser
                };
                changesLogBusiness.Create(changesLog);
            }
            else
            {
                productBusiness.Create(_viewModel.Product);
                ChangesLog changesLog = new ChangesLog()
                {
                    Date = DateTime.Now,
                    Description = "Creacion de nuevo Producto",
                    Module = "Producto",
                    User = LogInfo.LoggedUser
                };
                changesLogBusiness.Create(changesLog);
            }
            OnAddProductClicked();
        }

        private void ProviderTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (ProviderTextBox.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(ProviderTextBox.Text))
                {
                    Models.Provider provider = (Models.Provider)ProviderTextBox.SelectedItem;
                    ProviderTextBox.Text = provider.Company;
                    _viewModel.Product.Provider.Id = provider.Id;
                }
            }
        }
    }
}
