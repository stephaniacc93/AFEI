using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AFEI.Business;
using AFEI.Client.ViewModels;
using MahApps.Metro.Controls;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : MetroContentControl
    {
        HistoryBusiness historyBusiness = new HistoryBusiness();
        ChangesLogBusiness changesLogBusiness = new ChangesLogBusiness();
        private MenuViewModel _viewModel;
        public Menu()
        {
            InitializeComponent();
            _viewModel = new MenuViewModel();
            _viewModel.Histories = historyBusiness.GetList().OrderByDescending(x => x.Date).Take(10).ToList();
            _viewModel.ChangesLogs = changesLogBusiness.GetList().OrderByDescending(x => x.Date).Take(10).ToList();
            DataContext = _viewModel;
        }

    }
}
