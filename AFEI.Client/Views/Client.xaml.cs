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
        ClientBusiness clientBusiness = new ClientBusiness();

        public Client()
        {
            InitializeComponent();
            _viewModel = new ClientModel();
            _viewModel.Clients = clientBusiness.GetList();
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
