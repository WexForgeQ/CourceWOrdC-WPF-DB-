using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AllTrans.Model;
using System.ComponentModel;

namespace AllTrans.ViewModel
{
    public class DataManagerStopsPick: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void RoutePick(string routename)
        {
            _stops = new ObservableCollection<Stop>(DataWorker.GetStopsByRoute(routename));
            RefreshStops(routename);
        }
        public void NumberPick(string routename)
        {
            _transport = new ObservableCollection<Transport>(DataWorker.GetNumbersListByRoute(routename));
            RefreshTransport(routename);
        }

        private ObservableCollection<TransRoute> _transRoutesNames = new ObservableCollection<TransRoute>(DataWorker.GetRoutesWONum());
        public ObservableCollection<TransRoute> TransRoutes { get { return _transRoutesNames; } }

        private ObservableCollection<Stop> _stops = new ObservableCollection<Stop>(DataWorker.GetStopsByRoute(""));
        public ObservableCollection<Stop> Stops { get { return _stops; } }

        private ObservableCollection<Transport> _transport = new ObservableCollection<Transport>(DataWorker.GetNumbersListByRoute(""));
        public ObservableCollection<Transport> Transports { get { return _transport; } }

        public void RefreshStops(string routename)
        {
             _stops = new ObservableCollection<Stop>(DataWorker.GetStopsByRoute(routename));
            
            NotifyPropertyChange("Stops");
        }
        public void RefreshTransport(string routename)
        {
            _transport = new ObservableCollection<Transport>(DataWorker.GetNumbersListByRoute(routename));
            NotifyPropertyChange("Transports");
        }


    }
}