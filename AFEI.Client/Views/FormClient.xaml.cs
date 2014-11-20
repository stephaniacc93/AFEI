using System;
using AFEI.Business;
using AFEI.Client.Helpers;
using AFEI.Client.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for FormClient.xaml
    /// </summary>
    public partial class FormClient : MetroContentControl
    {
        private FormClientModel _viewModel;
        private Models.Client _client;
        ClientBusiness clientBusiness = new ClientBusiness();

        public FormClient()
        {
            InitializeComponent();
        }

        public FormClient(object o)
        {
            InitializeComponent();
            ClientBusiness clientBusiness = new ClientBusiness();
            _client = (AFEI.Models.Client)o;
            if (_client.Id != 0)
                _client = clientBusiness.Read(_client.Id);
            _viewModel = new FormClientModel(_client);
            DataContext = _viewModel;
            Notification.Text = "";
        }

        public delegate void AddClientClickedHandler();
        public event AddClientClickedHandler AddClientClicked;
        public void OnAddClientClicked()
        {
            if (AddClientClicked != null)
            {
                AddClientClicked();
            }
        }


        private  void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_viewModel.Client.error))
            {
                Notification.Text = "";
                if (_viewModel.Client.Id != 0)
                    clientBusiness.Update(_viewModel.Client);
                else
                    clientBusiness.Create(_viewModel.Client);
                OnAddClientClicked();
            }
            else
            {
                Notification.Text =
                    "Cliente no ha sido registrado, favor de ingresar los datos correspondientes";
            }
        }
    }
}
