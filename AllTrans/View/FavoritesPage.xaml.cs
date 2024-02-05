using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AllTrans.ViewModel;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для FavoritesPage.xaml
    /// </summary>
    public partial class FavoritesPage : Page
    {
        DataManagerFavorites favorites = new DataManagerFavorites();

        public FavoritesPage()
        {
            favorites.Fill();
            InitializeComponent();
            this.DataContext = favorites;
            
        }

        private void FullView(object sender, RoutedEventArgs e)
        {
            if(this.FavoritesList.SelectedItem!= null)
            {
                NavigationService.Navigate(new RoutePickPage(favorites.Favorite[this.FavoritesList.SelectedIndex].transid));
            }
            else
            {
                MessageBox.Show("Перед нажатием выберите элемент");
            }          
        }
    }
}
