using Dapper;
using System.Collections.Generic;

namespace WebStoreApplication.Models
{
    public class AccessDBContext: IAccessDBContext
    {
        public int AddProduct(ProductModel product)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.Product (UserID, ProductName, ProductDescription, Price, StatusID, TypeID, ProductImage) VALUES (@UserID, @ProductName, @ProductDescription, @Price, @StatusID, @TypeID, @ProductImage)";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {ProductName = product.productName, ProductDescription = product.productDescription, Price = product.price, UserID = product.userID, StatusID = product.statusID, TypeID = product.typeID, ProductImage = product.productImage,});
        }
        public int RemoveProduct(int productID)
        {
            string query = @"DELETE FROM [CoroNacessitiesDB].dbo.Product WHERE ProductID = @ProductID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {ProductID = productID});
        }
        public ProductModel GetProduct(int productID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Product WHERE ProductID = @ProductID";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<ProductModel>(query, new {ProductID = productID});
        }
        public int UpdateProduct(int id, ProductModel product)
        {

            string query = @"UPDATE [CoroNacessitiesDB].dbo.Product SET ProductName = @ProductName, ProductDescription = @ProductDescription, Price = @Price, UserID = @UserID, StatusID = @StatusID, TypeID = @TypeID, ProductImage = @ProductImage WHERE ProductID = @ProductID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {ProductName = product.productName, ProductDescription = product.productDescription, Price = product.price, UserID = product.userID, StatusID = product.statusID, TypeID = product.typeID, ProductImage = product.productImage, ProductID = id});
        } 
        public List<ProductModel> GetAllProducts()
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Product";
            return CoroNacessitiesDBContext.getConnection().Query<ProductModel>(query).AsList();
        }

        public UserModel GetUser(int userID)
        {
            string query = @"SELECT * FROM [dbo].[UserView] where id=@id;";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<UserModel>(query,new{ id = userID });
        }

        public int UpdateUser(int userID , UserModel user)
        {
            string query = @"UPDATE [CoroNacessitiesDB].[dbo].[AspNetUsers] SET Name = @Name, Surname=@Surname , Email,@Email ,PhoneNumber= @PhoneNumber, Rating=@Rating ,PayPalInfo = @PayPalInfo WHERE id = @id";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { id=userID, Name=user.Name , Surname = user.Surname , Email = user.Email , PhoneNumber = user.PhoneNumber , Rating = user.Rating , PayPalInfo = user.PayPalInfo});
        }

        // Order Items
        public int AddOrderItems(int orderItemID, OrderItemModel orderItem)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.OrderItem (OrderItemID, OrderID, ProductID, NoOfProducts) VALUES (@OrderItemID, @OrderID, @ProductID, @NoOfProducts)";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderItemID = orderItem.orderItemID, OrderID = orderItem.orderID, ProductID = orderItem.productID, NoOfProducts = orderItem.noOfProducts});
        }
        public int RemoveOrderItems(int orderItemID)
        {
            string query = @"DELETE FROM [CoroNacessitiesDB].dbo.OrderItem WHERE OrderItemID = @OrderItemID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderItemID = orderItemID });
        }
        public OrderItemModel GetOrderItems(int orderItemID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.OrderItem WHERE OrderItemID = @OrderItemID";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<OrderItemModel>(query, new { OrderItemID = orderItemID });
        }
        public int UpdateOrderItems(int orderItemID, OrderItemModel orderItem)
        {
            string query = @"UPDATE [CoroNacessitiesDB].dbo.OrderItem SET OrderItemID = @OrderItemID, OrderID = @OrderID, ProductID = @ProductID, NoOfProducts = @NoOfProducts WHERE OrderItemID = @OrderItemID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderItemID = orderItem.orderItemID, OrderID = orderItem.orderID, ProductID = orderItem.productID, NoOfProducts = orderItem.noOfProducts});
        }
        public List<OrderItemModel> GetAllOrderItems(int orderID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Orders WHERE OrderID = @OrderID";
            return CoroNacessitiesDBContext.getConnection().Query<OrderItemModel>(query, new { OrderID = orderID }).AsList();
        }


        // Orders
        public int AddOrder(OrdersModel order)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.Orders (OrderID, UserID, OrderStatusID) VALUES (@OrderID, @UserID, @OrderStatusID)";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderID = order.orderID, UserID = order.userID, OrderStatusID = order.orderStatusID});
        }
        public int RemoveOrder(int orderID)
        {
            string query = @"DELETE FROM [CoroNacessitiesDB].dbo.Orders WHERE OrderID = @OrderID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderID = orderID });
        }
        public OrdersModel GetOrder(int orderID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Orders WHERE OrderID = @OrderID";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<OrdersModel>(query, new { OrderID = orderID });
        }
        public int UpdateOrder(int orderID, OrdersModel order)
        {
            string query = @"UPDATE [CoroNacessitiesDB].dbo.Orders SET OrderID = @OrderID, UserID = @UserID, OrderStatusID = @OrderStatusID WHERE OrderID = @OrderID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderID = order.orderID, UserID = order.userID, OrderStatusID = order.orderStatusID});
        }
        public List<OrdersModel> GetAllOrdersForUser(int userID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Orders WHERE UserID = @UserID";
            return CoroNacessitiesDBContext.getConnection().Query<OrdersModel>(query, new { UserID = userID }).AsList();
        }


        // Order Status
        public int AddOrderStatus(OrderStatusModel orderStatus)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.OrderStatus (OrderStatusID, OrderStatusDescription) VALUES (@OrderStatusID, @OrderStatusDescription)";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderStatusID = orderStatus.orderStatusID, OrderStatusDescription = orderStatus.orderStatusDescription});
        }
        public int RemoveOrderStatus(int orderStatusID)
        {
            string query = @"DELETE FROM [CoroNacessitiesDB].dbo.OrderStatus WHERE OrderStatusID = @OrderStatusID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderStatusID = orderStatusID});
        }
        public OrdersModel GetOrderStatus(int orderStatusID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.OrderStatus WHERE OrderStatusID = @OrderStatusID";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<OrdersModel>(query, new { OrderStatusID = orderStatusID });
        }
        public int UpdateOrderStatus(int orderStatusID, OrderStatusModel orderStatus)
        {
            string query = @"UPDATE [CoroNacessitiesDB].dbo.OrderStatus SET OrderStatusID = @OrderStatusID, OrderStatusDescription = @OrderStatusDescription WHERE OrderID = @OrderID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderStatusID = orderStatus.orderStatusID, OrderStatusDescription = orderStatus.orderStatusDescription});
        }
        public List<OrderStatusModel> GetAllOrdersStatuses()
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.OrderStatus";
            return CoroNacessitiesDBContext.getConnection().Query<OrderStatusModel>(query).AsList();
        }
    }
}