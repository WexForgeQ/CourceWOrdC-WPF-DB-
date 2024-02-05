using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllTrans.Model
{
    public class FavoriteTransport
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public int transid { get; set; }
        public int stopid { get; set; }
        public int routeid { get; set; }
    }
}
