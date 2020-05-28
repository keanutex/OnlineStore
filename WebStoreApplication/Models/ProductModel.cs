namespace WebStoreApplication.Models
{
    public class ProductModel
    {
        public int productID {get; set;}
        public string productName {get; set;}
        public string productDescription {get; set;}
        public decimal price {get; set;}
        public int userID {get; set;}
        public int productStatusID {get; set;}
        public int typeID {get; set;}
        public TypeModel typeModel {get; set;}
        public byte [] productImage {get; set;}

        public ProductModel()
        {

        }
    }
}