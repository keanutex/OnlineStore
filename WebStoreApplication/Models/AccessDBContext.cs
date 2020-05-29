using Dapper;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace WebStoreApplication.Models
{
    public class AccessDBContext: IAccessDBContext
    {
        // Products
        public int AddProduct(ProductModel product)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.Product (UserID, ProductName, ProductDescription, Price, ProductStatusID, TypeID, ProductImage) VALUES (@UserID, @ProductName, @ProductDescription, @Price, @ProductStatusID, @TypeID, @ProductImage)";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {ProductName = product.productName, ProductDescription = product.productDescription, Price = product.price, UserID = product.userID, ProductStatusID = product.productStatusID, TypeID = product.typeID, ProductImage = product.productImage,});
        }
        public int RemoveProduct(int productID)
        {
            string query = @"DELETE FROM [CoroNacessitiesDB].dbo.Product WHERE ProductID = @ProductID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {ProductID = productID});
        }
        public ProductModel GetProduct(int productID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Product WHERE ProductID = @ProductID";
            ProductModel result = CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<ProductModel>(query, new {ProductID = productID});
            result.typeModel = GetAllProductTypes()[result.typeID-1];

            return result;
        }
        public int UpdateProduct(int id, ProductModel product)
        {

            string query = @"UPDATE [CoroNacessitiesDB].dbo.Product SET ProductName = @ProductName, ProductDescription = @ProductDescription, Price = @Price, UserID = @UserID, ProductStatusID = @ProductStatusID, TypeID = @TypeID, ProductImage = @ProductImage WHERE ProductID = @ProductID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {ProductName = product.productName, ProductDescription = product.productDescription, Price = product.price, UserID = product.userID, ProductStatusID = product.productStatusID, TypeID = product.typeID, ProductImage = product.productImage, ProductID = id});
        } 
        public List<ProductModel> GetAllProducts()
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Product";

            List<ProductModel> result = CoroNacessitiesDBContext.getConnection().Query<ProductModel>(query).AsList();

            foreach(ProductModel pm in result)
            {
                pm.typeModel = GetAllProductTypes()[pm.typeID-1];
            }

            return result;
        }
        public List<ProductModel> GetAllUserProducts(int userID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Product AS p WHERE p.UserID = @UserID";
            
            List<ProductModel> result = CoroNacessitiesDBContext.getConnection().Query<ProductModel>(query, new {UserID = userID}).AsList();
            foreach(ProductModel pm in result)
            {
                pm.typeModel = GetAllProductTypes()[pm.typeID-1];
            }

            return result;
        }

        public List<TypeModel> GetAllProductTypes()
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.ProductType ORDER BY TypeID ASC";
            return CoroNacessitiesDBContext.getConnection().Query<TypeModel>(query).AsList();
        }

        public int AddProductToCart(int userID, int orderStatusID, int productID, int noOfProducts)
        {
            string queryOrder = @"INSERT INTO [CoroNacessitiesDB].dbo.Orders (UserID, OrderStatusID) VALUES (@UserID, @OrderStatusID) SELECT SCOPE_IDENTITY() ;";
            int orderID = CoroNacessitiesDBContext.getConnection().ExecuteScalar<int>(queryOrder, new { UserId = userID, OrderStatusID = orderStatusID});

            string queryOrderItem = @"INSERT INTO [CoroNacessitiesDB].dbo.OrderItem (OrderID, ProductID, NoOfProducts) VALUES (@OrderID, @ProductID, @NoOfProducts)";
            return CoroNacessitiesDBContext.getConnection().Execute(queryOrderItem, new { OrderID = orderID, ProductID = productID, NoOfProducts = noOfProducts});
        }

        //User Details
        public UserModel GetUserByUsername(string username)
        {
            string query = @"SELECT * FROM [dbo].[Users] where Username=@Username;";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<UserModel>(query,new{ Username = username });
        }
        public UserModel GetUserById(int userId)
        {
            string query = @"SELECT * FROM [dbo].[Users] where UserID=@UserID;";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<UserModel>(query, new { UserID = userId });
        }

        public int UpdateUser(UserModel user)
        {
            string query = @"UPDATE [CoroNacessitiesDB].dbo.Users SET Password=@Password , Name = @Name, Surname=@Surname , Email=@Email ,ContactNo= @ContactNo, Rating=@Rating ,PayPalInfo = @PayPalInfo WHERE UserID = @UserID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {UserID=user.userId, Password = user.password, Name=user.name , Surname = user.surname , Email = user.email , ContactNo = user.contactNo , Rating = 0 , PayPalInfo = "" });
   
         }
        public int AddUser(RegisterModel user)
        {
            //string queryAddress = @"INSERT INTO [CoroNacessitiesDB].dbo.Address (ComplexName, UnitNumber, StreetName, StreetNumber, Suburb, CityID) VALUES (@ComplexName, @UnitNumber, @StreetName,@StreetNumber , @Suburb, @CityID) SELECT SCOPE_IDENTITY() ;";
            //int addressID = CoroNacessitiesDBContext.getConnection().ExecuteScalar<int>(queryAddress, new { ComplexName = user.complexName, UnitNumber = user.unitNumber, StreetName = user.streetName, StreetNumber = user.streetNumber, Suburb = user.suburb, CityID = user.cityID });

            string queryUser = @"INSERT INTO [CoroNacessitiesDB].dbo.Users (Username, Password, Name, Surname, Email, ContactNo , AddressID) VALUES (@Username, @Password, @Name, @Surname, @Email, @ContactNo , @AddressID)";
            return CoroNacessitiesDBContext.getConnection().Execute(queryUser, new { Username = user.username , Password = user.password , Name = user.name , Surname = user.surname , Email=user.email , ContactNo= user.contactNo, AddressID = 1 });
        }

        public string GetUserPassword(string username)
        {
            string query = @"SELECT Password FROM [dbo].[Users] where Username=@Username;";
            return CoroNacessitiesDBContext.getConnection().ExecuteScalar<string>(query, new { Username = username });
        }
        public int UpdateAddress(AddressModel address)
        {
            string query = @"UPDATE [CoroNacessitiesDB].dbo.Address SET ComplexName=@ComplexName, UnitNumber = @UnitNumber, StreetName=@StreetName , StreetNumber=@StreetNumber ,CityID= @CityID WHERE  AddressID = @AddressID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { ComplexName = address.complexName, UnitNumber = address.unitNumber, StreetName = address.streetName, StreetNumber = address.streetNumber, CityID = address.cityID , AddressID=address.addressID });

        }

        //Location Details
        public LocationModel GetLocation(string username)
        {
            string query = @"SELECT * FROM [dbo].[LocationView] where Username=@Username;";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<LocationModel>(query, new { Username = username });
        }

        public List<CityModel> GetAllCities()
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.City";
            return CoroNacessitiesDBContext.getConnection().Query<CityModel>(query).AsList();
        }
        
        public AddressModel GetAddress(int addressID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Address WHERE AddressID = @AddressID";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<AddressModel>(query, new { AddressID = addressID });

        }

        // Order Items
        public int AddOrderItems(OrderItemModel orderItem)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.OrderItem (OrderID, ProductID, NoOfProducts) VALUES (@OrderID, @ProductID, @NoOfProducts)";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderID = orderItem.orderID, ProductID = orderItem.productID, NoOfProducts = orderItem.noOfProducts});
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
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.Orders (UserID, OrderStatusID) VALUES (@UserID, @OrderStatusID); SELECT Orders.OrderID FROM [CoroNacessitiesDB].dbo.Orders WHERE Orders.UserID = @UserId AND Orders.OrderStatusID = @OrderStatusID SELECT SCOPE_IDENTITY()";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { UserID = order.userID, OrderStatusID = order.orderStatusID});
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

        public List<ProductModel> GetAllProductsInOrder(int userID, string statusDescription)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.Product
                                INNER JOIN OrderItem
                                ON Product.productId=OrderItem.ProductID
                                INNER JOIN Orders
                                ON OrderItem.OrderID=Orders.OrderID
                                INNER JOIN OrderStatus
                                ON Orders.OrderStatusID=OrderStatus.OrderStatusID
                                WHERE Orders.UserID = @UserID
                                AND OrderStatus.OrderStatusDescription = @StatusDescription";
            return CoroNacessitiesDBContext.getConnection().Query<ProductModel>(query, new { UserID = userID, statusDescription = statusDescription}).AsList();
        }

        public int EmptyCart(int userID)
        {
            string query = @"UPDATE Orders
                            SET OrderStatusID = 4
                            WHERE userID = @userID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { userID = userID });
        }


        // Order Status
        public int AddOrderStatus(OrderStatusModel orderStatus)
        {
            string query = @"INSERT INTO [CoroNacessitiesDB].dbo.OrderStatus (OrderStatusID, OrderStatusDescription) VALUES (@OrderStatusID, @OrderStatusDescription)";
            return CoroNacessitiesDBContext.getConnection().ExecuteScalar<int>(query, new { OrderStatusID = orderStatus.orderStatusID, OrderStatusDescription = orderStatus.orderStatusDescription});
        }
        public int RemoveOrderStatus(int orderStatusID)
        {
            string query = @"DELETE FROM [CoroNacessitiesDB].dbo.OrderStatus WHERE OrderStatusID = @OrderStatusID";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new { OrderStatusID = orderStatusID});
        }
        public OrderStatusModel GetOrderStatus(int orderStatusID)
        {
            string query = @"SELECT * FROM [CoroNacessitiesDB].dbo.OrderStatus WHERE OrderStatusID = @OrderStatusID";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<OrderStatusModel>(query, new { OrderStatusID = orderStatusID });
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