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
            OnAddClientClicked(new Models.Client());
        }

        public delegate void AddClientClickedHandler(object o);
        public event AddClientClickedHandler AddClientClicked;
        public void OnAddClientClicked(object o)
        {
            if (AddClientClicked != null)
            {
                AddClientClicked(o);
            }
        }

        public delegate void DeleteClientClickedHandler();
        public event DeleteClientClickedHandler DeleteClientClicked;
        public void OnDeleteClientClicked()
        {
            if (DeleteClientClicked != null)
            {
                DeleteClientClicked();
            }
        }

        private void EditClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            var o = (Models.Client)ClientDataGrid.SelectedItem;
            OnAddClientClicked(o);
        }

        private void DeleteClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            var o = (Models.Client)ClientDataGrid.SelectedItem;
            clientBusiness.Delete(o.Id);
            OnDeleteClientClicked();
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExportToExcel.Export(ClientDataGrid);
        }
    }
}
