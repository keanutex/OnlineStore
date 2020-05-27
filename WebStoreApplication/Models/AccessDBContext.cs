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

        public UserModel GetUser(string username)
        {
            string query = @"SELECT * FROM [dbo].[Users] where Username=@Username;";
            return CoroNacessitiesDBContext.getConnection().QuerySingleOrDefault<UserModel>(query,new{ Username = username });
        }

        public int UpdateUser(UserModel user)
        {
            string query = @"UPDATE [CoroNacessitiesDB].dbo.Users SET Password=@Password Name = @Name, Surname=@Surname , Email=@Email ,PhoneNumber= @PhoneNumber, Rating=@Rating ,PayPalInfo = @PayPalInfo WHERE Username = @Username";
            return CoroNacessitiesDBContext.getConnection().Execute(query, new {Username=user.username, Password = user.password, Name=user.name , Surname = user.surname , Email = user.email , ContactNo = user.contactNo , Rating = user.rating , PayPalInfo = user.payPalInfo });
   
         }
        public int AddUser(RegisterModel user)
        {
            string queryAddress = @"INSERT INTO [CoroNacessitiesDB].dbo.Address (ComplexName, UnitNumber, StreetName, StreetNumber, Suburb, CityID) VALUES (@ComplexName, @UnitNumber, @StreetName, @Suburb, @CityID)";
            CoroNacessitiesDBContext.getConnection().Execute(queryAddress, new { ComplexName = user.complexName, UnitNumber = user.unitNumber, StreetName = user.streetName, StreetNumber = user.streetNumber, Suburb = user.suburb, CityID = user.cityID });

            string queryUser = @"INSERT INTO [CoroNacessitiesDB].dbo.Users (Username, Password, Name, Surname, Email, ContactNo , Rating , PayPalInfo ,AddressID) VALUES (@Username, @Password, @Name, @Surname, @Email, @ContactNo , @Rating , @PayPalInfo , @AddressID)";
            return CoroNacessitiesDBContext.getConnection().Execute(queryUser, new { Username = user.username , Password = user.password , Name = user.name , Surname = user.surname , Email=user.email , ContactNo= user.contactNo, Rating = user.rating , PayPalInfo = user.payPalInfo , AddressID = user.addressId });
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

    }
}