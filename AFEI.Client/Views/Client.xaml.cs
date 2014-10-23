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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : MetroContentControl
    {
        public Client()
        {
            InitializeComponent();
        }

        private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnAddClientClicked();
        }

        public delegate void AddClientClickedHandler();
        public event AddClientClickedHandler AddClientClicked;
        public void OnAddClientClicked()
        {
            if (AddClientClicked != null)
            {
                AddClientClicked();
            }
        }
    }
}
