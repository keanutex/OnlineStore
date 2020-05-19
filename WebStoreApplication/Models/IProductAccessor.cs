using System.Collections.Generic;

namespace WebStoreApplication.Models
{
    public interface IProductAccessor
    {
        public void AddProduct(ProductModel product);
        public void RemoveProduct(int productID);
        public ProductModel GetProduct(int productID);
        public void UpdateProduct(int id, ProductModel product); 
        public List<ProductModel> GetAllProducts();
    }
}