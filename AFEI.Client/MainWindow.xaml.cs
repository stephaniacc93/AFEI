using AFEI.Client.Views;
using MahApps.Metro.Controls;
using System.Windows;

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
        Notifications notifications = new Notifications();

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

        private void NotificationsButton_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = notifications;
        }
    }
}
