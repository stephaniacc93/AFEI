using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AFEI.Business;
using AFEI.Client.ViewModels;
using AFEI.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for InventoryOutput.xaml
    /// </summary>
    public partial class InventoryOutput : MetroContentControl
    {
        private InventoryModificationViewModel _viewModel;
        ProviderBusiness providerBusiness = new ProviderBusiness();
        ProductBusiness productBusiness = new ProductBusiness();
        ChangesLogBusiness changesLogBusiness = new ChangesLogBusiness();
        HistoryBusiness historyBusiness = new HistoryBusiness();

        public InventoryOutput(object o)
        {
            InitializeComponent();
            Product p = (Product)o;
            _viewModel = new InventoryModificationViewModel();
            _viewModel.Product = p;
            _viewModel.History = new History();
            DataContext = _viewModel;
        }

        public InventoryOutput()
        {

        }

        private void OutputProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_viewModel.History.error) && _viewModel.History.Quantity <= _viewModel.Product.Quantity  && _viewModel.History.Quantity > 0 && !string.IsNullOrWhiteSpace(_viewModel.History.Quantity.ToString()))
           
            {
                if (_viewModel.History.Quantity == _viewModel.Product.Quantity)
                {
                    _viewModel.Product.Quantity = 0;
                }
                else
                    _viewModel.Product.Quantity -= _viewModel.History.Quantity;
                productBusiness.Update(_viewModel.Product);
                _viewModel.History.Product = _viewModel.Product;
                _viewModel.History.Provider = _viewModel.Product.Provider;
                _viewModel.History.User = LogInfo.LoggedUser;
                _viewModel.History.TransactionType = "Reduccion de Inventario";
                ChangesLog changesLog = new ChangesLog()
                {
                    Date = DateTime.Now,
                    Description = "Baja de Inventario",
                    Module = "Producto",
                    User = LogInfo.LoggedUser
                };
                changesLogBusiness.Create(changesLog);
                historyBusiness.Create(_viewModel.History);
                OnOutputInventoryClicked();
            }
            else
            {
                NtTextBlock.Text =
                     "Los cambios no han sido registrados, favor de ingresar los datos correspondientes";
            }
        }

        public delegate void OutputInventoryClickedHandler();
        public event OutputInventoryClickedHandler OutputInventoryClicked;
        public void OnOutputInventoryClicked()
        {
            if (OutputInventoryClicked != null)
            {
                OutputInventoryClicked();
            }
        }
    }
}
