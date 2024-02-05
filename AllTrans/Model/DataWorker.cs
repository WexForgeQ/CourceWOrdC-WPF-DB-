using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AllTrans.Model
{
    public static class DataWorker
    {
        //НЕ ИСПОЛЬЗОВАТЬ ЭТОТ ПОЗОР
        //public static void Add()
        //{
        //    using (ApplicationContext dv = new ApplicationContext())
        //    {
        //        int id = 1;
        //        for(int i = 1; i<37; i++)
        //        {
        //                TimeSpan time1 = new TimeSpan(6, 5, 0);
        //                TimeSpan time2 = new TimeSpan(10, 15, 0);
        //                TimeSpan time3 = new TimeSpan(16, 30, 0);
        //                StopTime route1 = new StopTime();
        //                StopTime route2 = new StopTime();
        //                StopTime route3 = new StopTime();
        //                route1.id = id++;
        //                route1.stoprouteid = i;
        //                DateTime addtime1 = DateTime.Parse((time1 + TimeSpan.FromMinutes(id)).ToString());                       
        //                route1.timeval = addtime1.ToString("t");
        //                dv.StopsTime.Add(route1);

        //                route2.id = id++;
        //                route2.stoprouteid = i;
        //                DateTime addtime2 = DateTime.Parse((time2 + TimeSpan.FromMinutes(id)).ToString());
        //                route2.timeval = addtime2.ToString("t");
        //                dv.StopsTime.Add(route2);

        //                route3.id = id++;
        //                route3.stoprouteid = i;
        //                DateTime addtime3 = DateTime.Parse((time3 + TimeSpan.FromMinutes(id)).ToString());
        //                route3.timeval = addtime3.ToString("t");
        //                dv.StopsTime.Add(route3);                      
        //        }
        //        dv.SaveChanges();
        //    }
        //}



        public static ObservableCollection<Transport> GetNumbersList(string _transtype)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Transport> collection = new ObservableCollection<Transport>(db.Transport.ToList<Transport>());
                return new ObservableCollection<Transport>(collection.Where(el => el.trastype == _transtype));
            }
        }
        public static ObservableCollection<Transport> GetNumbersListByRoute(string route)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Transport> collection = new ObservableCollection<Transport>(db.Transport.ToList<Transport>());
                ObservableCollection<TransRoute> collectionRoute = new ObservableCollection<TransRoute>(db.TransRoute.ToList<TransRoute>());
                int routeid = 1;
                foreach (var item in collectionRoute)
                {
                    if (item.name == route)
                        routeid = item.id;
                }
                var transport = from t in collection
                                join tr in collectionRoute on t.id equals tr.transid
                                where tr.id == routeid
                                select t;
                return new ObservableCollection<Transport>(transport);
            }
        }
        public static ObservableCollection<TransRoute> GetRoutesById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<TransRoute> collectionRoute = new ObservableCollection<TransRoute>(db.TransRoute.ToList<TransRoute>());
                return new ObservableCollection<TransRoute>(collectionRoute.Where(tr => tr.transid == id));
            }
        }
        public static ObservableCollection<Stop> GetStopsByRoute(string _routename)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Stop> collectionStop = new ObservableCollection<Stop>(db.Stops.ToList<Stop>());
                ObservableCollection<TransRoute> collectionRoute = new ObservableCollection<TransRoute>(db.TransRoute.ToList<TransRoute>());
                ObservableCollection<StopRoute> collectionStopRoutes = new ObservableCollection<StopRoute>(db.StopsRoute.ToList<StopRoute>());
                int routeid = 1;
                foreach (var item in collectionRoute)
                {
                    if (item.name == _routename)
                        routeid = item.id;
                }
                var stopRoutes = collectionStopRoutes.Where(sr => sr.routeid == routeid);
                var stops = collectionStop.Where(s => stopRoutes.Any(sr => sr.stopid == s.id));
                ObservableCollection<Stop> outputStop = new ObservableCollection<Stop>(stops);
                return outputStop;
            }
        }

        public static ObservableCollection<StopTime> GetTimeByRouteAndStop(int routeid, int stopid)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<StopRoute> stopRoutes = new ObservableCollection<StopRoute>(db.StopsRoute.ToList<StopRoute>());
                var stops = stopRoutes.Where(sr => sr.routeid == routeid && sr.stopid == stopid);
                ObservableCollection<StopTime> collectionTime = new ObservableCollection<StopTime>(db.StopsTime.ToList<StopTime>());
                var transport = from t in collectionTime
                                join tr in stops on t.stoprouteid equals tr.id
                                where tr.id == t.stoprouteid
                                select t;
                return new ObservableCollection<StopTime>(transport);
            }

        }



        public static ObservableCollection<TransRoute> GetRoutesByNum(int transnumber)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<TransRoute> collection = new ObservableCollection<TransRoute>(db.TransRoute.ToList<TransRoute>());
                return new ObservableCollection<TransRoute>(collection.Where(el => el.transid == transnumber));
            }
        }
        public static ObservableCollection<TransRoute> GetRoutesWONum()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return new ObservableCollection<TransRoute>(db.TransRoute.ToList<TransRoute>());
            }
        }

        public static void CreateUser(string login, string email, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Users.Any(el => el.uslogin == login))
                {
                    var rep = new UserRepository(db);
                    var uow = new UnitOfWork();
                    User newUser = new User{uslogin = login, email = email, uspass = password, Avatar = @"\Images\Terence.png", usertype = "user" };
                    rep.Create(newUser);
                    uow.Save();
                    
                }
            }
        }

        public static bool CheckUserLogin(string login)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                AppSettings._possibleLogin = login;
                return db.Users.FirstOrDefault(el => el.uslogin == login) == null ? false : true;
            }
        }
        public static bool CheckUserEmail(string email)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.FirstOrDefault(el => el.email == email) == null ? false : true;
            }
        }
        public static bool CheckUserPassword(string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                AppSettings.localUser = db.Users.FirstOrDefault(el => el.uslogin == AppSettings._possibleLogin && el.uspass == password);
                return AppSettings.localUser == null ? false : true;
            }
        }
        public static async void  AddToFavorites(int tid, int rid, int sid)
        {
           
            using (ApplicationContext db = new ApplicationContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var favoirteaw = await db.FavoriteTransport.ToListAsync();
                    FavoriteTransport favorite = new FavoriteTransport() { userid = AppSettings.localUser.id, transid = tid, stopid = sid, routeid = rid };
                    db.FavoriteTransport.Add(favorite);
                    db.SaveChanges();
                    transaction.Commit();
                }
               
            }
        }
        public static ObservableCollection<FavoriteTransport> GetFavorite(int userid)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<FavoriteTransport> collection = new ObservableCollection<FavoriteTransport>(db.FavoriteTransport.ToList<FavoriteTransport>());
                return new ObservableCollection<FavoriteTransport>(collection.Where(el => el.userid == userid));
            }
        }
        public  static TransRoute GetRouteByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<TransRoute> collection = new ObservableCollection<TransRoute>(db.TransRoute.ToList<TransRoute>());
                ObservableCollection <TransRoute> routes = new ObservableCollection<TransRoute>(collection.Where(el => el.id == id));
                return routes[0];
            }

        }
        public static Stop GetStopByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Stop> collection = new ObservableCollection<Stop>(db.Stops.ToList<Stop>());
                ObservableCollection<Stop> stops = new ObservableCollection<Stop>(collection.Where(el => el.id == id));
                return stops[0];
            }

        }
        public static ObservableCollection<Transport> GetTransportByID(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Transport> collection = new ObservableCollection<Transport>(db.Transport.ToList<Transport>());
                return new ObservableCollection<Transport>(collection.Where(el => el.id == id));
            }

        }
    }
}
