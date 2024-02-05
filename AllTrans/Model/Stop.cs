using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    public class Stop
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public string name { get; set; }

    }
}
