using Microsoft.AspNetCore.Identity;

namespace WebStoreApplication.Models
{
    public class UserModel : IdentityUser<int>
    {

        public override int Id { get; set;}
        public override string UserName { get; set; }
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public int Rating {get; set;}
        public string PayPalInfo { get; set; }
        public int AddressID {get;set;}

        public UserModel()
        {

        }
    }
}