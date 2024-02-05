using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AllTrans.Model;
using System.ComponentModel;
using System.Linq;

namespace AllTrans.ViewModel
{
    public class DataManagerRouteByNumber: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void StopPick(string routename)
        {
            _stops = new ObservableCollection<Stop>(DataWorker.GetStopsByRoute(routename));
            RefreshStops(routename);
        }
        public void RoutePick(int id)
        {
            _transRoutesNames = new ObservableCollection<TransRoute>(DataWorker.GetRoutesById(id));
            RefreshRoute(id);
        }

        private ObservableCollection<TransRoute> _transRoutesNames = new ObservableCollection<TransRoute>(DataWorker.GetRoutesById(0));
        public ObservableCollection<TransRoute> TransRoutes { get { return _transRoutesNames; } }

        private ObservableCollection<Stop> _stops = new ObservableCollection<Stop>(DataWorker.GetStopsByRoute(""));
        public ObservableCollection<Stop> Stops { get { return _stops; } }

        private ObservableCollection<StopTime> _time = new ObservableCollection<StopTime>(DataWorker.GetTimeByRouteAndStop(0,0));
        public ObservableCollection<StopTime> Time { get { return _time; } }

        private ObservableCollection<Transport> _transport = new ObservableCollection<Transport>(DataWorker.GetNumbersListByRoute(""));
        public ObservableCollection<Transport> Transports { get { return _transport; } }

        public void RefreshStops(string routename)
        {
            _stops = new ObservableCollection<Stop>(DataWorker.GetStopsByRoute(routename));

            NotifyPropertyChange("Stops");
        }
        public void RefreshRoute(int id)
        {
            _transRoutesNames = new ObservableCollection<TransRoute>(DataWorker.GetRoutesById(id));
            NotifyPropertyChange("TransRoutes");
        }
        public void RefreshTime(int id, int sid)
        {
        _time = new ObservableCollection<StopTime>(DataWorker.GetTimeByRouteAndStop(id, sid));
        NotifyPropertyChange("Time");
        }
        public void SetTime(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StopTime time = db.StopsTime.First(el => el.id == id);
                time.timeval = TimeSpan.Parse(Data.newtime);
                db.SaveChanges();
            }
        }
        public void SetName(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                TransRoute route = db.TransRoute.First(el => el.id == id);
                route.name = Data.newRoute;
                db.SaveChanges();
            }
        }
        public void SetStop(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Stop stop = db.Stops.First(el => el.id == id);
                stop.name = Data.newstop;
                db.SaveChanges();
            }
        }

    }
}
