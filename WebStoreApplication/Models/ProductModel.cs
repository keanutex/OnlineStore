namespace WebStoreApplication.Models
{
    public class ProductModel
    {
        public int productID {get; set;}
        public string productName {get; set;}
        public string productDescription {get; set;}
        public decimal price {get; set;}
        public int userID {get; set;}

        public ProductModel()
        {

        }
    }
}