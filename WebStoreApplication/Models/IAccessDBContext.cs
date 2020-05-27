using System.Collections.Generic;
namespace WebStoreApplication.Models
{
    public interface IAccessDBContext
    {
        public int AddProduct(ProductModel product);
        public int RemoveProduct(int productID);
        public ProductModel GetProduct(int productID);
        public int UpdateProduct(int id, ProductModel product); 
        public List<ProductModel> GetAllProducts();
        public UserModel GetUser(string username);
        public int UpdateUser(UserModel user);
        public string GetUserPassword(string username);
        public int AddUser(RegisterModel user);
        public int UpdateAddress(AddressModel address);




    }
}