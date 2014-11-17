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
            client.AddClientClicked += client_AddClientClicked;
            client.DeleteClientClicked += client_DeleteClientClicked;
            formProduct.AddProductClicked += FormProductFormProductClicked;
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            provider.AddProviderClicked += provider_AddProviderClicked;
            formProvider.AddProviderClicked += FormProviderFormProviderClicked;
        }

        void client_DeleteClientClicked()
        {
            client = new Views.Client();
            client.AddClientClicked += client_AddClientClicked;
            client.DeleteClientClicked += client_DeleteClientClicked;
            Content.Content = client;
        }

        void inventory_DeleteProductClicked()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
        }


        void inventory_AddInventoryClicked(object o)
        {
            inventoryEntry = new InventoryEntry(o);
            inventoryEntry.AddInventoryClicked += inventoryEntry_AddInventoryClicked;
            Content.Content = inventoryEntry;
        }

        void inventoryEntry_AddInventoryClicked()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
        }

        void inventory_OutputInventoryClicked(object o)
        {
            inventoryOutput = new InventoryOutput(o);
            inventoryOutput.OutputInventoryClicked += inventoryOutput_OutputInventoryClicked;
            Content.Content = inventoryOutput;
        }

        void inventoryOutput_OutputInventoryClicked()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
        }

        void FormProviderFormProviderClicked()
        {
            Content.Content = provider;
        }

        void provider_AddProviderClicked(object o)
        {
            formProvider = new FormProvider(o);
            Content.Content = formProvider;
        }

        void inventory_AddProductClicked(object o)
        {
            formProduct = new FormProduct(o);
            formProduct.AddProductClicked += formProduct_AddProductClicked;
            Content.Content = formProduct;
        }

        void formProduct_AddProductClicked()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
        }

        void FormProductFormProductClicked()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
        }


        void client_AddClientClicked(object o)
        {
            formClient = new FormClient(o);
            formClient.AddClientClicked += formClient_AddClientClicked;
            Content.Content = formClient;
        }

        void formClient_AddClientClicked()
        {
            client = new Views.Client();
            client.AddClientClicked += client_AddClientClicked;
            client.DeleteClientClicked += client_DeleteClientClicked;
            Content.Content = client;
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
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
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
