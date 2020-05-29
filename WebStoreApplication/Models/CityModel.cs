using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class CityModel
    {
        public int cityId { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string cityName { get; set; }
       

        public CityModel()
        {

        }
    }
}
