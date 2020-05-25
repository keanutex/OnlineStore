using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts { get; }
        IEnumerable<ProductModel> GetCandyOnSale { get; }
        ProductModel GetProductById(int productID);
    }
}