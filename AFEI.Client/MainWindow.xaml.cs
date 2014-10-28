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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AFEI.Client.Views;
using MahApps.Metro.Controls;

namespace AFEI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Views.Menu menu = new Views.Menu();
        Provider provider = new Provider();
        Views.Client client = new Views.Client();
        Inventory inventory = new Inventory();
        ChangesHistory changesHistory = new ChangesHistory();
        ProductHistory productHistory = new ProductHistory();
        FormClient formClient = new FormClient();
        Login login = new Login();
        FormProduct formProduct = new FormProduct();
        FormProvider formProvider = new FormProvider();

        public MainWindow()
        {
            InitializeComponent();
            Content.Content = menu;
            client.AddClientClicked += client_AddClientClicked;
            formClient.AddClientClicked += FormClientFormClientClicked;
            formProduct.AddProductClicked += FormProductFormProductClicked;
            inventory.AddProductClicked += inventory_AddProductClicked;
            provider.AddProviderClicked += provider_AddProviderClicked;
            formProvider.AddProviderClicked += FormProviderFormProviderClicked;
        }

        void FormProviderFormProviderClicked()
        {
            Content.Content = provider;
        }

        void provider_AddProviderClicked()
        {
            Content.Content = formProvider;
        }

        void inventory_AddProductClicked()
        {
            Content.Content = formProduct;
        }

        void FormProductFormProductClicked()
        {
            Content.Content = inventory;
        }

        void FormClientFormClientClicked()
        {
            Content.Content = client;
        }

        void client_AddClientClicked()
        {
            Content.Content = formClient;
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = menu;
        }

        private void ProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = provider;
        }

        private void ClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = client;
        }

        private void InventoryButton_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = inventory;
        }

        private void HistoryButton_OnClick(object sender, RoutedEventArgs e)
        {
            HistoryButton.ContextMenu.IsOpen = true;
        }


        private void ProductHistory_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = productHistory;
        }

        private void ChangesHistory_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = changesHistory;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = login;
        }

        private void LogoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void UserButton_OnClick(object sender, RoutedEventArgs e)
        {
            UserButton.ContextMenu.IsOpen = true;
        }
    }
}
