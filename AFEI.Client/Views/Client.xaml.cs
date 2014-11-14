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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : MetroContentControl
    {
        private ClientModel _viewModel;
        private List<Models.Client> _clients;
        public Client()
        {
            InitializeComponent();
        }

        public Client(Object o)
        {
            InitializeComponent();
            ClientBusiness clientBusiness = new ClientBusiness();
            _clients = (List<AFEI.Models.Client>)o;
            _clients = clientBusiness.GetList();
            _viewModel = new ClientModel(_clients);
            DataContext = _viewModel;
        }

        private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddClientClicked();
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

        private void EditClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddClientClicked();
        }

        private void DeleteClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ClientDataGrid);
        }
    }
}
