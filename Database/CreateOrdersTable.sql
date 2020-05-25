DROP TABLE IF EXISTS CoroNacessitiesDB.dbo.Orders;
--Create Orders table
CREATE TABLE CoroNacessitiesDB.dbo.Orders(
[EntryIntoTableID] INT IDENTITY(1,1) NOT NULL,
[OrderID] INT NOT NULL,
[UserID] INT NOT NULL,
[ProductID] INT NOT NULL,
[NoOfProducts] INT NOT NULL,
[OrderStatusID] INT NOT NULL,
PRIMARY KEY ([EntryIntoTableID])
);
GO