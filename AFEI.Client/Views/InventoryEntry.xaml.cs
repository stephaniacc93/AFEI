using System;
using AFEI.Business;
using AFEI.Client.ViewModels;
using AFEI.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for InventoryEntry.xaml
    /// </summary>
    public partial class InventoryEntry : MetroContentControl
    {
        private InventoryModificationViewModel _viewModel;
        ProviderBusiness providerBusiness = new ProviderBusiness();
        ProductBusiness productBusiness = new ProductBusiness();
        ChangesLogBusiness changesLogBusiness = new ChangesLogBusiness();
        HistoryBusiness historyBusiness = new HistoryBusiness();

        public InventoryEntry(object o)
        {
            InitializeComponent();
            Product p = (Product)o;
            _viewModel = new InventoryModificationViewModel();
            _viewModel.Product = p;
            _viewModel.History = new History();
            DataContext = _viewModel;
        }

        public InventoryEntry()
        {
                
        }

        public delegate void AddInventoryClickedHandler();
        public event AddInventoryClickedHandler AddInventoryClicked;
        public void OnAddInventoryClicked()
        {
            if (AddInventoryClicked != null)
            {
                AddInventoryClicked();
            }
        }

        private async void AddProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.History.Quantity >= 0)
            {
                _viewModel.Product.Quantity += _viewModel.History.Quantity;
                productBusiness.Update(_viewModel.Product);
                OnAddInventoryClicked();
                _viewModel.History.User = LogInfo.LoggedUser;
                _viewModel.History.Product = _viewModel.Product;
                _viewModel.History.Provider = _viewModel.Product.Provider;
                _viewModel.History.TransactionType = "Aumento de Inventario";
                ChangesLog changesLog = new ChangesLog()
                {
                    Date = DateTime.Now,
                    Description = "Se anadio Inventario",
                    Module = "Producto",
                    User = LogInfo.LoggedUser
                };
                changesLogBusiness.Create(changesLog);
                historyBusiness.Create(_viewModel.History);
            }
            else
            {
               //falta validacion
            }

        }
    }
}
