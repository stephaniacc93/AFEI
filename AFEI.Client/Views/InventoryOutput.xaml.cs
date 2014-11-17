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

        public InventoryOutput(object o)
        {
            InitializeComponent();
            Product p = (Product)o;
            _viewModel = new InventoryModificationViewModel();
            _viewModel.Product = p;
            DataContext = _viewModel;
        }

        public InventoryOutput()
        {
                
        }

        private void OutputProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.QuantityModification >= 0 && _viewModel.QuantityModification < _viewModel.Product.Quantity)
            {
                _viewModel.Product.Quantity -= _viewModel.QuantityModification;
                productBusiness.Update(_viewModel.Product);
                OnOutputInventoryClicked();
            }
            else
            {
               //falta validacion
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
