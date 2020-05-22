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
    }
}