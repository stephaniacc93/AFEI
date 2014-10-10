﻿using System;
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
using MahApps.Metro.Controls;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : MetroContentControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BotonPrueba_OnClick(object sender, RoutedEventArgs e)
        {
            BotonPrueba.ContextMenu.Placement = PlacementMode.Mouse;
            BotonPrueba.ContextMenu.IsOpen = true;

        }
    }
}
