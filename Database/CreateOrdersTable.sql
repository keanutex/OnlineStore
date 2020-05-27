DROP TABLE IF EXISTS CoroNacessitiesDB.dbo.Orders;
--Create Orders table
CREATE TABLE CoroNacessitiesDB.dbo.Orders(
[OrderID] INT IDENTITY(1,1) NOT NULL,
[UserID] INT NOT NULL,
[OrderStatusID] INT NOT NULL,
PRIMARY KEY ([OrderID])
);