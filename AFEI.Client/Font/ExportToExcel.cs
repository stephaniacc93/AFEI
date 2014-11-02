using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Microsoft.Windows.Controls;
using Xceed.Wpf.DataGrid.Views;
using DataGridClipboardCopyMode = System.Windows.Controls.DataGridClipboardCopyMode;

namespace AFEI.Client.Font
{
    public static class ExportToExcel
    {
        public static void Export(System.Windows.Controls.DataGrid dataGrid)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.DefaultExt = ".xls";
            dlg.Filter = "Text documents (.xls)|*.xls";

            Nullable<bool> r = dlg.ShowDialog();

            if (r == true)
            {
                dataGrid.SelectAllCells();
                dataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dataGrid);
                String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
                String result = (string)Clipboard.GetData(DataFormats.Text);
                dataGrid.UnselectAllCells();
                System.IO.StreamWriter file = new System.IO.StreamWriter(dlg.FileName);
                file.WriteLine(result.Replace(',', ' '));
                file.Close();
            }
        }
    }
}
