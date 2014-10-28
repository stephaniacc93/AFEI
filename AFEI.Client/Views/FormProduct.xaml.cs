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
    /// Interaction logic for FormProduct.xaml
    /// </summary>
    public partial class FormProduct : MetroContentControl
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        public delegate void AddProductClickedHandler();
        public event AddProductClickedHandler AddProductClicked;
        public void OnAddProductClicked()
        {
            if (AddProductClicked != null)
            {
                AddProductClicked();
            }
        }

        private void AddProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddProductClicked();
        }
    }
}
