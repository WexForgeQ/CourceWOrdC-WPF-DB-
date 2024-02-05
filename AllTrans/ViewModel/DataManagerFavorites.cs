using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AllTrans.Model;
using System.ComponentModel;
using System.Windows;

namespace AllTrans.ViewModel
{
    public class DataManagerFavorites
    {
        private ObservableCollection<FavoriteTransport> favorites = new ObservableCollection<FavoriteTransport>(DataWorker.GetFavorite(AppSettings.localUser.id));
        public ObservableCollection<FavoriteTransport> Favorite { get { return favorites; } }

        private ObservableCollection<FavoriteFull> full = new ObservableCollection<FavoriteFull>();
        public ObservableCollection<FavoriteFull> FavoriteFull { get { return full; } }

        
        public void Fill()
        {
            foreach(var item in Favorite)
            {
                full.Add(new FavoriteFull(item.transid, DataWorker.GetRouteByID(item.routeid).name, DataWorker.GetStopByID(item.stopid).name));
            }
        }
    }
}
