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

        // Order Items
        public int AddOrderItems(int orderItemID, OrderItemModel orderItem);
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


        // Order Status
        public int AddOrderStatus(OrderStatusModel orderStatus);
        public int RemoveOrderStatus(int orderStatusID);
        public OrderStatusModel GetOrderStatus(int orderStatusID);
        public int UpdateOrderStatus(int orderStatusID, OrderStatusModel orderStatus);
        public List<OrderStatusModel> GetAllOrdersStatuses();

    }
}