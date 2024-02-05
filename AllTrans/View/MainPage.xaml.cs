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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        SearchTypePage searchTypePage = new SearchTypePage();
        
        public MainPage()
        {
            InitializeComponent();
            SearchTypeFrame.Navigate(searchTypePage);
        }
       
        private void TrollButtonEvent(object sender, MouseButtonEventArgs e)
        {
            this.TransportNav.ColumnDefinitions[0].Width = new GridLength(33, GridUnitType.Star);
            this.BusButton.ColumnDefinitions[0].Width = new GridLength(0);
            this.TransportNav.ColumnDefinitions[1].Width = new GridLength(66, GridUnitType.Star);
            this.TrollButton.ColumnDefinitions[0].Width = new GridLength(70, GridUnitType.Star);
            this.TrollButton.ColumnDefinitions[1].Width = new GridLength(30, GridUnitType.Star);
            this.TransportNav.ColumnDefinitions[2].Width = new GridLength(33, GridUnitType.Star);
            this.TramButton.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
            this.TramButton.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            Model.Data.SelectedType = "troll";
            if(Model.Data.NumberListStatus)
            {
                NumberPick numberPick = new NumberPick();
                SearchTypeFrame.Navigate(numberPick);
            }

        }

        private void BussButtonEvent(object sender, MouseButtonEventArgs e)
        {
            this.TransportNav.ColumnDefinitions[0].Width = new GridLength(66, GridUnitType.Star);
            this.BusButton.ColumnDefinitions[0].Width = new GridLength(0);
            this.TransportNav.ColumnDefinitions[1].Width = new GridLength(33, GridUnitType.Star);
            this.BusButton.ColumnDefinitions[0].Width = new GridLength(70, GridUnitType.Star);
            this.BusButton.ColumnDefinitions[1].Width = new GridLength(30, GridUnitType.Star);
            this.TrollButton.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
            this.TrollButton.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            this.TransportNav.ColumnDefinitions[2].Width = new GridLength(33, GridUnitType.Star);
            this.TramButton.ColumnDefinitions[0].Width = new GridLength(0);
            Model.Data.SelectedType = "bus";
            if (Model.Data.NumberListStatus)
            {
                NumberPick numberPick = new NumberPick();
                SearchTypeFrame.Navigate(numberPick);
            }
        }

        private void TramButtonEvent(object sender, MouseButtonEventArgs e)
        {
            this.TransportNav.ColumnDefinitions[0].Width = new GridLength(33, GridUnitType.Star);
            this.BusButton.ColumnDefinitions[0].Width = new GridLength(0);
            this.TransportNav.ColumnDefinitions[1].Width = new GridLength(33, GridUnitType.Star);
            this.TramButton.ColumnDefinitions[0].Width = new GridLength(70, GridUnitType.Star);
            this.TramButton.ColumnDefinitions[1].Width = new GridLength(30, GridUnitType.Star);
            this.TrollButton.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
            this.TrollButton.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            this.TransportNav.ColumnDefinitions[2].Width = new GridLength(66, GridUnitType.Star);
            Model.Data.SelectedType = "tram";
            if (Model.Data.NumberListStatus)
            {
                NumberPick numberPick = new NumberPick();
                SearchTypeFrame.Navigate(numberPick);
            }
        }
    }
}
