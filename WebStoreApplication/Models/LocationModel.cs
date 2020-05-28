using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class LocationModel
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }

        public LocationModel()
        {

        }
    }
}
