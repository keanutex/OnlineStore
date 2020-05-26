DROP TABLE IF EXISTS CoroNacessitiesDB.dbo.OrderItem;
--Create OrderItem table
CREATE TABLE CoroNacessitiesDB.dbo.OrderItem(
[OrderItemID] INT IDENTITY(1,1) NOT NULL,
[OrderID] INT NOT NULL,
[ProductID] INT NOT NULL,
[NoOfProducts] INT NOT NULL,
PRIMARY KEY ([OrderItemID])
);