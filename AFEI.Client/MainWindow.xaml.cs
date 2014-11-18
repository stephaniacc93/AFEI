using AFEI.Client.Views;
using MahApps.Metro.Controls;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

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
        InventoryEntry inventoryEntry = new InventoryEntry();
        InventoryOutput inventoryOutput = new InventoryOutput();

        public MainWindow()
        {
            InitializeComponent();
            Content.Content = menu;
        }

        void client_DeleteClientClicked()
        {
            GoToClient();
        }

        private void GoToClient()
        {
            client = new Views.Client();
            client.AddClientClicked += client_AddClientClicked;
            client.DeleteClientClicked += client_DeleteClientClicked;
            Content.Content = client;
        }

        void inventory_DeleteProductClicked()
        {
            GoToInventory();
        }


        void inventory_AddInventoryClicked(object o)
        {
            GoToInventoryEntry(o);
        }

        private void GoToInventoryEntry(object o)
        {
            inventoryEntry = new InventoryEntry(o);
            inventoryEntry.AddInventoryClicked += inventoryEntry_AddInventoryClicked;
            Content.Content = inventoryEntry;
        }

        void inventoryEntry_AddInventoryClicked()
        {
            GoToInventory();
        }

        void inventory_OutputInventoryClicked(object o)
        {
            GoToInventoryOutput(o);
        }

        private void GoToInventoryOutput(object o)
        {
            inventoryOutput = new InventoryOutput(o);
            inventoryOutput.OutputInventoryClicked += inventoryOutput_OutputInventoryClicked;
            Content.Content = inventoryOutput;
        }

        void inventoryOutput_OutputInventoryClicked()
        {
            GoToInventory();
        }

        void provider_AddProviderClicked(object o)
        {
            GoToFormProvider(o);
        }

        private void GoToFormProvider(object o)
        {
            formProvider = new FormProvider(o);
            formProvider.AddProviderClicked += formProvider_AddProviderClicked;
            Content.Content = formProvider;
        }

        void formProvider_AddProviderClicked()
        {
            GoToProvider();
        }

        private void GoToProvider()
        {
            provider = new Provider();
            provider.AddProviderClicked += provider_AddProviderClicked;
            Content.Content = provider;
        }

        private void GoToInventory()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
        }

        void inventory_AddProductClicked(object o)
        {
            GoToFormProduct(o);
        }

        private void GoToFormProduct(object o)
        {
            formProduct = new FormProduct(o);
            formProduct.AddProductClicked += formProduct_AddProductClicked;
            Content.Content = formProduct;
        }

        void formProduct_AddProductClicked()
        {
            GoToInventory();
        }



        void client_AddClientClicked(object o)
        {
            GoToFormClient(o);
        }

        private void GoToFormClient(object o)
        {
            formClient = new FormClient(o);
            formClient.AddClientClicked += formClient_AddClientClicked;
            Content.Content = formClient;
        }

        void formClient_AddClientClicked()
        {
            GoToClient();
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = menu;
        }

        private void ProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            GoToProvider();
        }

        private void ClientButton_OnClick(object sender, RoutedEventArgs e)
        {
           GoToClient();
        }

        private void InventoryButton_OnClick(object sender, RoutedEventArgs e)
        {
            GoToInventory();
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
