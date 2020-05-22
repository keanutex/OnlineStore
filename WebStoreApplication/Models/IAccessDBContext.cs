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
        public UserModel GetUser(int userID);
        public int UpdateUser(int userID ,UserModel user);
        

    }
}