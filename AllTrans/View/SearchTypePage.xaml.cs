using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для SearchTypePage.xaml
    /// </summary>
    public partial class SearchTypePage : Page
    {
        public SearchTypePage()
        {
            InitializeComponent();
        }

        private void TransSearchClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new NumberPick());
            Model.Data.NumberListStatus = true;
            Model.Data.StopListStatus = false;

        }

        private void StopsSearchClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new StopsPickPage());
            Model.Data.StopListStatus = true;
            Model.Data.NumberListStatus = false;
        }

        private void StopsSearchHover(object sender, MouseEventArgs e)
        { 
            var animation = new DoubleAnimation
            {
                To = 40,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            this.StopsText.BeginAnimation(TextBlock.FontSizeProperty, animation);
        }
        private void StopsSearchLeft(object sender, MouseEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                To = 30,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            this.StopsText.BeginAnimation(TextBlock.FontSizeProperty, animation);
        }

        private void TransSearchHover(object sender, MouseEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                To = 40,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            this.TransText.BeginAnimation(TextBlock.FontSizeProperty, animation);
        }
        private void TransSearchLeft(object sender, MouseEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                To = 30,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            this.TransText.BeginAnimation(TextBlock.FontSizeProperty, animation);
        }
    }
}
