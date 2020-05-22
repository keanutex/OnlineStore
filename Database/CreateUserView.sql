create view UserView as 
SELECT [Id],[UserName],[Name],[Surname],[Email],[PhoneNumber],[Rating],[PayPalInfo],[AddressID] 
FROM [dbo].[AspNetUsers] 