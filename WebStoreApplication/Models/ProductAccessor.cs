using System.Collections.Generic;
using System.Linq;

namespace WebStoreApplication.Models
{
    public class ProductAccessor: IProductAccessor
    {
        public void AddProduct(ProductModel product)
        {
            product.productID = ProductsContext.nextProductID++;
            ProductsContext.aggregate.products.Add(product);
        }
        public void RemoveProduct(int productID)
        {
            ProductsContext.aggregate.products.RemoveAll(pr => pr.productID == productID);
        }
        public ProductModel GetProduct(int productID)
        {
            return ProductsContext.aggregate.products.Where(pr => pr.productID == productID).SingleOrDefault();
        }

        public List<ProductModel> GetAllProducts()
        {
            return ProductsContext.aggregate.products;
        }  

        public void UpdateProduct(int id, ProductModel product)
        {
            int index = ProductsContext.aggregate.products.FindIndex(pr => pr.productID == id);
            ProductsContext.aggregate.products[index].productName = product.productName;
            ProductsContext.aggregate.products[index].productDescription = product.productDescription;
            ProductsContext.aggregate.products[index].price = product.price;
            ProductsContext.aggregate.products[index].userID = product.userID;        
        } 
    }
}