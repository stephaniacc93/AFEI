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

        public InventoryEntry(object o)
        {
            InitializeComponent();
            Product p = (Product)o;
            _viewModel = new InventoryModificationViewModel();
            _viewModel.Product = p;
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
            if (_viewModel.QuantityModification >= 0)
            {
                _viewModel.Product.Quantity += _viewModel.QuantityModification;
                productBusiness.Update(_viewModel.Product);
                OnAddInventoryClicked();
            }
            else
            {
               //falta validacion
            }

        }
    }
}
