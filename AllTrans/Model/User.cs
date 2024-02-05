using System;
using System.Collections.Generic;
using System.Text;

namespace AllTrans.Model
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public string usertype { get; set; }
        public string uslogin { get; set; }
        public string uspass { get; set; }
        public string email { get; set; }
        public string Avatar { get; set; }

    }
}
