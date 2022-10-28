using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineArtGallery.Models
{
    public class UserAuthClass
    {
        //id users fname lname email contacto cantactt adress region city country pcode gender pass

        public int id { get; set; }
        public string users { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string contacto { get; set; }
        public string contactt { get; set; }
        public string adress { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string pcode { get; set; }
        public string gender { get; set; }
        public string pass { get; set; }
    }
}