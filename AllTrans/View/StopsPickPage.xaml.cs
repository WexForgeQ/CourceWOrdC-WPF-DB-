using AllTrans.Model;
using AllTrans.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для StopsPickPage.xaml
    /// </summary>
    public partial class StopsPickPage : Page
    {
        DataManagerStopsPick stopsPick = new DataManagerStopsPick();
        public StopsPickPage()
        {
            InitializeComponent();
            this.DataContext = stopsPick;
        }

        private void SelectionRouteEvent(object sender, SelectionChangedEventArgs e)
        {
            stopsPick.RoutePick(((TransRoute)this.RouteList.SelectedItem).name);
            stopsPick.NumberPick(((TransRoute)this.RouteList.SelectedItem).name);
        }

        private void PickEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(this.RouteList.SelectedIndex%2 ==0)
            {
                NavigationService.Navigate(new RoutePickPage(((Transport)this.TimeList.SelectedItem).id, 0, this.StopsList.SelectedIndex));
            }
            else
            {
                NavigationService.Navigate(new RoutePickPage(((Transport)this.TimeList.SelectedItem).id, 1, this.StopsList.SelectedIndex));
            }
            
        }
    }
}
