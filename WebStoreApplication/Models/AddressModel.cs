using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class AddressModel
    {
        public int addressID { get; set; }
        public string complexName { get; set; }
        public int unitNumber { get; set; }
        public string streetName { get; set; }
        public int streetNumber { get; set; }
        public string suburb { get; set; }
        public int cityID { get; set; }

        public AddressModel()
        {

        }
    }
}
