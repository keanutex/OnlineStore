using System.Collections.Generic;
namespace WebStoreApplication.Models
{
    public interface IAccessDBContext
    {
        // Products
        public int AddProduct(ProductModel product);
        public int RemoveProduct(int productID);
        public ProductModel GetProduct(int productID);
        public int UpdateProduct(int id, ProductModel product); 
        public List<ProductModel> GetAllProducts();
        public List<ProductModel> GetAllUserProducts(int userID);
        public List<TypeModel> GetAllProductTypes();

        public int AddProductToCart(int userID, int orderStatusID, int productID, int noOfProducts);

        //User Details
        public UserModel GetUser(string username);
        public int UpdateUser(UserModel user);
        public string GetUserPassword(string username);
        public int AddUser(RegisterModel user);
        public int UpdateAddress(AddressModel address);

        //Location Details
        public LocationModel GetLocation(string username);
        public List<CityModel> GetAllCities();
        public AddressModel GetAddress(int addressID);
      
        // Order Items
        public int AddOrderItems(OrderItemModel orderItem);
        public int RemoveOrderItems(int orderItemID);
        public OrderItemModel GetOrderItems(int orderItemID);
        public int UpdateOrderItems(int orderItemID, OrderItemModel orderItem);
        public List<OrderItemModel> GetAllOrderItems(int orderID);

        // Orders
        public int AddOrder(OrdersModel order);
        public int RemoveOrder(int orderID);
        public OrdersModel GetOrder(int orderID);
        public int UpdateOrder(int orderID, OrdersModel order);
        public List<OrdersModel> GetAllOrdersForUser(int userID);
        public List<ProductModel> GetAllProductsInOrder(int userID, string statusDescription);


        // Order Status
        public int AddOrderStatus(OrderStatusModel orderStatus);
        public int RemoveOrderStatus(int orderStatusID);
        public OrderStatusModel GetOrderStatus(int orderStatusID);
        public int UpdateOrderStatus(int orderStatusID, OrderStatusModel orderStatus);
        public List<OrderStatusModel> GetAllOrdersStatuses();

    }
}