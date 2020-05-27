using Microsoft.AspNetCore.Identity;

namespace WebStoreApplication.Models
{
    public class UserModel
    {

        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public int rating { get ; set; } 
        public string payPalInfo { get; set; }
        public int addressId { get; set; }

        public UserModel()
        {

        }
    }
}