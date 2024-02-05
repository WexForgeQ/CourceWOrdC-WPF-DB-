using AllTrans.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllTrans.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool NavStat = true;
        private MainPage mainPage = new MainPage();
        private LogIn logIn = new LogIn();
        public MainWindow()
        {
            InitializeComponent();
            ContentContainer.Navigate(mainPage);
        }

        private void CoverNav(object sender, MouseButtonEventArgs e)
        {
            if(NavStat)
            {
                this.NavPanel.ColumnDefinitions[2].Width = new GridLength(0);
                this.NavPanel.ColumnDefinitions[3].Width = new GridLength(0);
                this.CoverImage.Source = new BitmapImage(new Uri(@"\Images\Arrow.png", UriKind.Relative));
                NavStat = false;
            }
            else
            {
                this.NavPanel.ColumnDefinitions[2].Width = new GridLength(75);
                this.NavPanel.ColumnDefinitions[3].Width = new GridLength(75);
                this.CoverImage.Source = new BitmapImage(new Uri(@"\Images\ArrowBack.png", UriKind.Relative));
                NavStat = true;
            }
            
        }

        private void HomeButton(object sender, MouseButtonEventArgs e)
        {
            ContentContainer.Navigate(new MainPage());
            mainPage.SearchTypeFrame.Navigate(new View.SearchTypePage());
            Model.Data.NumberListStatus = false;
            Model.Data.StopListStatus = false;
        }

        private void FavoritesNav(object sender, MouseButtonEventArgs e)
        {
            if(Data.UserIsAdmin)
            {
                MessageBox.Show("Администратор не имеет права просматривать избранное");
            }
            else
            {
                ContentContainer.Navigate(new FavoritesPage());
                Model.Data.NumberListStatus = false;
                Model.Data.StopListStatus = false;
            }  
        }

        private void LogEvent(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            LogIn log = new LogIn();
            Data.UserLogin = false;
            Data.UserIsAdmin = false;
            log.Show();           
        }
    }
}
