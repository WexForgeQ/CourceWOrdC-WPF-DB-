using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    public class Transport
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public int number { get; set; }
        public string trastype { get; set; }
        public string Avatar { get; set; }
        
    }
}
