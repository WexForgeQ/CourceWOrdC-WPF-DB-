using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    
    public class StopRoute
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public int routeid { get; set; }
        public int stopid { get; set; }
        public int quenum { get; set; }
    }
}
