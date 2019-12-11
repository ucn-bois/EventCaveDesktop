using Resources.Utils;
using System.Windows;
using System.Windows.Controls;

namespace EventCaveDesktop
{
    public partial class Login : Page
    {
        Authentication auth = Authentication.GetInstance();
        public Login()
        {
            InitializeComponent();
            if (auth.UserLoggedIn())
            {
                loginBtn.Content = "You are logged in";
                loginBtn.IsEnabled = false;
            }
        }

        private void Log_In_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (auth.LogIn(userNameBox.Text, passwordBox.Password))
            {
                loginBtn.Content = "You are now logged in";
                loginBtn.IsEnabled = false;
            }
            else
            {
                loginBtn.Content = "Loggin in failed.";
            }
        }
    }
}
