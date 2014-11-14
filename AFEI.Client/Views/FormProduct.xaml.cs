using AFEI.Business;
using AFEI.Client.ViewModels;
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
            OnAddProductClicked();
        }
    }
}
