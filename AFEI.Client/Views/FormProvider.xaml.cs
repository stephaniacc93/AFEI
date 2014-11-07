using AFEI.Business;
using AFEI.Client.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for FormProvider.xaml
    /// </summary>
    public partial class FormProvider : MetroContentControl
    {
        private FormProviderModel _viewModel;
        private Models.Provider _provider;

        public FormProvider()
        {
                
        }
        public FormProvider(object o)
        {
            InitializeComponent();
            ProviderBusiness providerBusiness = new ProviderBusiness();
            _provider = (AFEI.Models.Provider)o;
            if (_provider.Id != 0)
                _provider = providerBusiness.Read(_provider.Id);
            _viewModel = new FormProviderModel(_provider);
            DataContext = _viewModel;
        }

        public delegate void AddProviderClickedHandler();
        public event AddProviderClickedHandler AddProviderClicked;
        public void OnAddProviderClicked()
        {
            if (AddProviderClicked != null)
            {
                AddProviderClicked();
            }
        }

        private void AddProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddProviderClicked();
        }
    }
}
