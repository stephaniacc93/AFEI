using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;
using AFEI.Client.Font;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using Microsoft.Windows.Controls.Primitives;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for Provider.xaml
    /// </summary>
    public partial class Provider : MetroContentControl
    {
        public Provider()
        {
            InitializeComponent();
            Models.Provider provider = new Models.Provider();
            provider.Id = 1;
            provider.FirstName = "Juan";
            provider.LastName = "Perez";
            provider.Phone = "3456789";
            provider.Company = "Empresa";
            provider.Email = "juan@perez.com";
            List<Models.Provider> providers = new List<Models.Provider>();
            providers.Add(provider);
            ProviderDataGrid.ItemsSource = providers;
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

        private void EditProvider_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddProviderClicked();
        }

        private void DeleteProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
           ExportToExcel.Export(ProviderDataGrid);
        }
    }
}
