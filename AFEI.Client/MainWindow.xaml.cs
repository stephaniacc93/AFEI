using System.Linq;
using AFEI.Business;
using AFEI.Client.Views;
using AFEI.Models;
using MahApps.Metro.Controls;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Provider = AFEI.Client.Views.Provider;

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
        ProductBusiness productBusiness = new ProductBusiness();

        public MainWindow()
        {
            InitializeComponent();
            if (LogInfo.LoggedUser == null)
            {
                UserStackPanel.Visibility = Visibility.Hidden;
                LoginStackPanel.Visibility = Visibility.Visible;
                ProviderButton.Visibility = Visibility.Hidden;
                ClientButton.Visibility = Visibility.Hidden;
                InventoryButton.Visibility = Visibility.Hidden;
                HistoryButton.Visibility = Visibility.Hidden;
            }
            else
            {
                UserStackPanel.Visibility = Visibility.Visible;
                LoginStackPanel.Visibility = Visibility.Hidden;
                ProviderButton.Visibility = Visibility.Visible;
                ClientButton.Visibility = Visibility.Visible;
                InventoryButton.Visibility = Visibility.Visible;
                HistoryButton.Visibility = Visibility.Visible;
                Content.Content = new Menu();
                UserTextBlock.Text = LogInfo.LoggedUser.Firstname;
            }
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void client_DeleteClientClicked()
        {
            GoToClient();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToClient()
        {
            client = new Views.Client();
            client.AddClientClicked += client_AddClientClicked;
            client.DeleteClientClicked += client_DeleteClientClicked;
            Content.Content = client;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void inventory_DeleteProductClicked()
        {
            GoToInventory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }


        void inventory_AddInventoryClicked(object o)
        {
            GoToInventoryEntry(o);
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToInventoryEntry(object o)
        {
            inventoryEntry = new InventoryEntry(o);
            inventoryEntry.AddInventoryClicked += inventoryEntry_AddInventoryClicked;
            Content.Content = inventoryEntry;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void inventoryEntry_AddInventoryClicked()
        {
            GoToInventory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void inventory_OutputInventoryClicked(object o)
        {
            GoToInventoryOutput(o);
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToInventoryOutput(object o)
        {
            inventoryOutput = new InventoryOutput(o);
            inventoryOutput.OutputInventoryClicked += inventoryOutput_OutputInventoryClicked;
            Content.Content = inventoryOutput;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void inventoryOutput_OutputInventoryClicked()
        {
            GoToInventory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void provider_AddProviderClicked(object o)
        {
            GoToFormProvider(o);
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToFormProvider(object o)
        {
            formProvider = new FormProvider(o);
            formProvider.AddProviderClicked += formProvider_AddProviderClicked;
            Content.Content = formProvider;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void formProvider_AddProviderClicked()
        {
            GoToProvider();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToProvider()
        {
            provider = new Provider();
            provider.AddProviderClicked += provider_AddProviderClicked;
            Content.Content = provider;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToInventory()
        {
            inventory = new Inventory();
            inventory.AddProductClicked += inventory_AddProductClicked;
            inventory.AddInventoryClicked += inventory_AddInventoryClicked;
            inventory.OutputInventoryClicked += inventory_OutputInventoryClicked;
            inventory.DeleteProductClicked += inventory_DeleteProductClicked;
            Content.Content = inventory;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void inventory_AddProductClicked(object o)
        {
            GoToFormProduct(o);
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToFormProduct(object o)
        {
            formProduct = new FormProduct(o);
            formProduct.AddProductClicked += formProduct_AddProductClicked;
            Content.Content = formProduct;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void formProduct_AddProductClicked()
        {
            GoToInventory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }



        void client_AddClientClicked(object o)
        {
            GoToFormClient(o);
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void GoToFormClient(object o)
        {
            formClient = new FormClient(o);
            formClient.AddClientClicked += formClient_AddClientClicked;
            Content.Content = formClient;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void formClient_AddClientClicked()
        {
            GoToClient();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void HomeButton_OnClick(object sender, RoutedEventArgs e)
        {
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
            if (LogInfo.LoggedUser != null)
                Content.Content = new Menu();
        }

        private void ProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            GoToProvider();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void ClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            GoToClient();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void InventoryButton_OnClick(object sender, RoutedEventArgs e)
        {
            GoToInventory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void HistoryButton_OnClick(object sender, RoutedEventArgs e)
        {
            HistoryButton.ContextMenu.IsOpen = true;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }


        private void ProductHistory_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = new ProductHistory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void ChangesHistory_OnClick(object sender, RoutedEventArgs e)
        {
            Content.Content = new ChangesHistory();
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            login = new Login();
            login.LoggedInClicked += login_LoggedInClicked;
            Content.Content = login;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        void login_LoggedInClicked()
        {
            if (LogInfo.LoggedUser == null)
            {
                UserStackPanel.Visibility = Visibility.Hidden;
                LoginStackPanel.Visibility = Visibility.Visible;
                ProviderButton.Visibility = Visibility.Hidden;
                ClientButton.Visibility = Visibility.Hidden;
                InventoryButton.Visibility = Visibility.Hidden;
                HistoryButton.Visibility = Visibility.Hidden;
            }
            else
            {
                UserStackPanel.Visibility = Visibility.Visible;
                LoginStackPanel.Visibility = Visibility.Hidden;
                ProviderButton.Visibility = Visibility.Visible;
                ClientButton.Visibility = Visibility.Visible;
                InventoryButton.Visibility = Visibility.Visible;
                HistoryButton.Visibility = Visibility.Visible;
                Content.Content = new Menu();
                UserTextBlock.Text = LogInfo.LoggedUser.Firstname;
            }
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void LogoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            UserTextBlock.Text = "";
            NotificationsButton.Content = "";
            LogInfo.LoggedUser = null;
            UserStackPanel.Visibility = Visibility.Hidden;
            LoginStackPanel.Visibility = Visibility.Visible;
            ProviderButton.Visibility = Visibility.Hidden;
            ClientButton.Visibility = Visibility.Hidden;
            InventoryButton.Visibility = Visibility.Hidden;
            HistoryButton.Visibility = Visibility.Hidden;
            Content.Content = null;

        }

        private void UserButton_OnClick(object sender, RoutedEventArgs e)
        {
            UserButton.ContextMenu.IsOpen = true;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }

        private void NotificationsButton_OnClick(object sender, RoutedEventArgs e)
        {
            notifications = new Notifications();
            Content.Content = notifications;
            NotificationsButton.Content = productBusiness.GetList().Count(x => x.Quantity < 10);
        }
    }
}
