using AllTrans.Model;
using AllTrans.ViewModel;
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
using System.Windows.Threading;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для RoutePickPage.xaml
    /// </summary>
    public partial class RoutePickPage : Page
    {

        public DataManagerRouteByNumber dataManager = new DataManagerRouteByNumber();
        public ObservableCollection<string> time = new ObservableCollection<string>();
        public int id;
        int index = 0;
        public TimeSpan future;
        public TimeSpan past;
        public TimeSpan farpast;
        public TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("T"));
        public bool FullViewStatus = false;
        public RoutePickPage(int id)
        {
            InitializeComponent();
            if (Data.UserIsAdmin)
            {
                this.AdminButton.Visibility = Visibility.Visible;
                this.FavoritesButton.Visibility = Visibility.Hidden;
            }               
            else
            {
                this.AdminButton.Visibility = Visibility.Hidden;
                this.FavoritesButton.Visibility = Visibility.Visible;
            }
            this.DataContext = dataManager;
            this.id = id;
            dataManager.RoutePick(id);
            this.RouteList.SelectedIndex = 0;
            
        }
        public RoutePickPage(int id, int rid, int sid)
        {
            InitializeComponent();
            if (Data.UserIsAdmin)
                this.AdminButton.Visibility = Visibility.Visible;
            else
                this.AdminButton.Visibility = Visibility.Hidden;
            this.DataContext = dataManager;
            this.id = id;
            dataManager.RoutePick(id);
            this.RouteList.SelectedIndex = rid;
            this.StopsList.SelectedIndex = sid;
            index = sid;
        }


        public void GetNearestTimes()
        {
            past = TimeSpan.MinValue;
            future = TimeSpan.MaxValue;
            farpast = TimeSpan.MinValue;
            foreach (string t in time)
            {
                TimeSpan temp = TimeSpan.Parse(t);
                if (temp > now && temp < future)
                {
                    future = temp;
                    break;
                }
            }
            int index = time.IndexOf(future.ToString());
            if (index == 0)
            {
                past =TimeSpan.Parse(time[time.Count - 1]);
                farpast = TimeSpan.Parse(time[index + 1]);
            }
            else if (index == time.Count - 1)
            {
                past = TimeSpan.Parse(time[index-1]);
                farpast = TimeSpan.Parse(time[0]);
            }
            else
            {
                past = TimeSpan.Parse(time[index-1]);
                farpast = TimeSpan.Parse(time[index+1]);
            }



        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RealDate.Text = DateTime.Now.ToString("HH:mm:ss");
            GetNearestTimes();
            Close.Text = future.ToString("t");
            Far.Text = farpast.ToString("t");
            Prev.Text = past.ToString("t");
        }

        private void FullViewClick(object sender, RoutedEventArgs e)
        {
            if(!FullViewStatus)
            {
                this.FullViewButtonText.Text = "Ближайшие маршруты";
                this.ContentNumberGrid.RowDefinitions[0].Height = new GridLength(0);
                this.ContentNumberGrid.RowDefinitions[1].Height = new GridLength(70, GridUnitType.Star);
                this.ContentNumberGrid.RowDefinitions[2].Height = new GridLength(30, GridUnitType.Star);
                this.ContentNumberGrid.RowDefinitions[3].Height = new GridLength(0);
                FullViewStatus = true;

            }
            else
            {
                this.FullViewButtonText.Text = "Просмотр полного расписания";
                this.ContentNumberGrid.RowDefinitions[0].Height = new GridLength(100, GridUnitType.Star);
                this.ContentNumberGrid.RowDefinitions[1].Height = new GridLength(0);
                this.ContentNumberGrid.RowDefinitions[2].Height = new GridLength(100, GridUnitType.Star);
                this.ContentNumberGrid.RowDefinitions[3].Height = new GridLength(100, GridUnitType.Star);
                FullViewStatus = false;
            }
           
        }

        private void RouteSelectEvent(object sender, SelectionChangedEventArgs e)
        {
            dataManager.StopPick(((TransRoute)this.RouteList.SelectedItem).name);
            this.StopsList.SelectedIndex = index;
        }

        private void StopPickEvent(object sender, SelectionChangedEventArgs e)
        {
            if (this.StopsList.SelectedItem != null)
            {
                time.Clear();
                dataManager.RefreshTime(((TransRoute)this.RouteList.SelectedItem).id, ((Stop)this.StopsList.SelectedItem).id);
                foreach (var item in dataManager.Time)
                {
                    this.time.Add(item.timeval.ToString());
                }
                GetNearestTimes();
                RealDate.Text = now.ToString();
                Close.Text = future.ToString();
                Far.Text = farpast.ToString();
                Prev.Text = past.ToString();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();
            }         
        }

        private void FavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            DataWorker.AddToFavorites(this.id, ((TransRoute)this.RouteList.SelectedItem).id, ((Stop)this.StopsList.SelectedItem).id);
        }
        private void AdminClick(object sender, RoutedEventArgs e)
        {
            if(this.TimeList.SelectedItem!= null)
            {
                try
                {
                    int index = ((TransRoute)this.RouteList.SelectedItem).id;
                    int indexof = ((StopTime)this.TimeList.SelectedItem).id;
                    int ind = ((Stop)this.StopsList.SelectedItem).id;
                    Data.newtime = ((StopTime)this.TimeList.SelectedItem).timeval.ToString();
                    TimeChangeWin timeChangeWin = new TimeChangeWin();
                    timeChangeWin.ShowDialog();
                    dataManager.SetTime(indexof);
                    dataManager.SetName(index);
                    dataManager.SetStop(ind);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
              
            }
            

        }
    }
}
