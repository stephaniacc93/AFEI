using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace AFEI.Client.Helpers
{
    public static class DialogService
    {
        public static async Task<MessageDialogResult> ShowMessage(string title
           , string message)
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            return await metroWindow.ShowMessageAsync(
                title, message, MessageDialogStyle.Affirmative, metroWindow.MetroDialogOptions);
        }
    }
}
