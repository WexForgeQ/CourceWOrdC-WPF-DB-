using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    public class FavoriteFull
    {
        public int Number { get; set; }
        public string Route { get; set; }
        public string Stop { get; set; }

        public FavoriteFull(int nm, string rt, string st)
        {
            Number = nm;
            Route = rt;
            Stop = st;
        }
    }
}
