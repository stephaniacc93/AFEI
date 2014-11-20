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
using AFEI.Models;
using AFEI.Business;

namespace AFEI.Client.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroContentControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Notification.Text = "";
            string username = UserTextBox.Text;
            string password = PasswordTextBox.Password;
            if (isUserValid(username, password))
            {
                OnLoggedInClicked();
            }
            else
            {
                Notification.Text = "Usuario o contrasena incorrecta";
            }
        }

        public delegate void LoggedInClickedHandler();
        public event LoggedInClickedHandler LoggedInClicked;
        public void OnLoggedInClicked()
        {
            if (LoggedInClicked != null)
            {
                LoggedInClicked();
            }
        }

        private bool isUserValid(string username, string password)
        {
            UserBusiness userB = new UserBusiness();
            List<User> users = userB.GetList();
            foreach (User user in users)
            {
                bool isUsernameCorrect = false;
                bool isPasswordCorrect = false;
                if (user.Username == username)
                    isUsernameCorrect = true;
                if (user.Password == password)
                    isPasswordCorrect = true;
                if (isUsernameCorrect && isPasswordCorrect)
                {
                    LogInfo.LoggedUser = users.Single(x => x.Username == username && x.Password == password);
                    return true;
                }
            }
            return false;
        }
    }
}
