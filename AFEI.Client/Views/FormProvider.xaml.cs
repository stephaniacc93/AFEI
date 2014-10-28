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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for FormProvider.xaml
    /// </summary>
    public partial class FormProvider : MetroContentControl
    {
        public FormProvider()
        {
            InitializeComponent();
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
    }
}
