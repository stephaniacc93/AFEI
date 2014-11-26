using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using AFEI.Business;
using AFEI.Client.Font;
using AFEI.Client.ViewModels;
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
        private ProviderModel _providerModel;
        ProviderBusiness providerBusiness = new ProviderBusiness();
        private string _Filter;

        public Provider()
        {
            _providerModel = new ProviderModel();
            _providerModel.Providers = providerBusiness.GetList();
            InitializeComponent();
            DataContext = _providerModel;
        }

        public delegate void AddProviderClickedHandler(object o);
        public event AddProviderClickedHandler AddProviderClicked;
        public void OnAddProviderClicked(object o)
        {
            if (AddProviderClicked != null)
            {
                AddProviderClicked(o);
            }
        }

        private void AddProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddProviderClicked(new Models.Provider());
        }

        private void EditProvider_OnClick(object sender, RoutedEventArgs e)
        {
            Models.Provider  p = (Models.Provider)ProviderDataGrid.SelectedItem;
            OnAddProviderClicked(p);
        }

        private void DeleteProviderButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExportToExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
           ExportToExcel.Export(ProviderDataGrid);
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ProviderDataGrid.ItemsSource);
            _Filter = SearchTextBox.Text.ToLower();
            view.Filter = new Predicate<object>(Filters);
        }

        private bool Filters(object obj)
        {
            Models.Provider provider = obj as Models.Provider;
            if (provider.Company.ToLower().Contains(_Filter) || provider.LastName.ToLower().Contains(_Filter) || provider.FirstName.ToLower().Contains(_Filter))
                return true;
            else
                return false;
        }
    }
}
