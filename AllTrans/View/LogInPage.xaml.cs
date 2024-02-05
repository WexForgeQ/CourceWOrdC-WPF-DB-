using AllTrans.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogIn _LogIn;
        public LogInPage(LogIn logIn)
        {
            InitializeComponent();
            _LogIn = logIn;
            this.DataContext = new DataManagerLogIn();
        }
        private void LogIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LogIn.Text.Length > 0)
            {
                LogInPlug.Visibility = Visibility.Hidden;
            }
            else
            {
                LogInPlug.Visibility = Visibility.Visible;
            }
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordIn.Text.Length > 0)
            {
                PasswordPlug.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordPlug.Visibility = Visibility.Visible;
            }
        }

        private void RegisterEvent(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage(_LogIn));
        }
    }
}
