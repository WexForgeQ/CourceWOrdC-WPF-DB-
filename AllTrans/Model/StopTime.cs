using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    public class StopTime
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public int stoprouteid { get; set; }
        public TimeSpan timeval { get; set; }

        public static explicit operator StopTime(int v)
        {
            throw new NotImplementedException();
        }
    }
}
