using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
using AFEI.Models;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        public Product Product { get; set; }
        public Notification(Product p)
        {
            InitializeComponent();
            Product = p;
            DataContext = Product;
            QuantityTextBlock.Text = p.Quantity.ToString();
        }
    }
}
