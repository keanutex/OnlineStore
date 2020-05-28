using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{

    public class RegisterModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public int rating { get; set; }
        public string payPalInfo { get; set; }
        public string complexName { get; set; }
        public int unitNumber { get; set; }
        public string streetName { get; set; }
        public int streetNumber { get; set; }
        public string suburb { get; set; }
        public int cityID { get; set; }

        public RegisterModel()
        {

        }
    }
}
