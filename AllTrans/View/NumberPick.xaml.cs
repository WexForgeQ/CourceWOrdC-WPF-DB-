using AllTrans.Model;
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
    /// Логика взаимодействия для NumberPick.xaml
    /// </summary>
    public partial class NumberPick : Page
    {
        public NumberPick()
        {
            InitializeComponent();
            if(Model.Data.SelectedType == "bus")
            {
                this.ListNumberGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                this.ListNumberGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);
                this.ListNumberGrid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Star);
            }
            else if(Model.Data.SelectedType == "troll")
            {
                this.ListNumberGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                this.ListNumberGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
                this.ListNumberGrid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Star);
            }
            else if (Model.Data.SelectedType == "tram")
            {
                this.ListNumberGrid.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);
                this.ListNumberGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);
                this.ListNumberGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
            }
            this.DataContext =  new DataManagerNumberPick();
        }

        private void NumberPickEvent(object sender, MouseButtonEventArgs e)
        {
            if (Model.Data.SelectedType == "bus")
            {
                NavigationService.Navigate(new RoutePickPage(((Transport)this.BusNumberList.SelectedItem).id));
            }
            else if (Model.Data.SelectedType == "troll")
            {
                NavigationService.Navigate(new RoutePickPage(((Transport)this.TrollNumberList.SelectedItem).id));
            }
            else if (Model.Data.SelectedType == "tram")
            {
                NavigationService.Navigate(new RoutePickPage(((Transport)this.TramNumberList.SelectedItem).id));
            }
           
        }
    }
}
