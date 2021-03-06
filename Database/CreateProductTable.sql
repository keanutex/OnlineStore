DROP TABLE IF EXISTS dbo.Product;
CREATE TABLE CoroNacessitiesDB.dbo.Product(
[ProductID] INT IDENTITY(1,1) NOT NULL,
[UserID] INT NOT NULL,
[ProductName] VARCHAR(50) NOT NULL,
[ProductDescription] VARCHAR(250) NOT NULL,
[Price] DECIMAL(10,2) NOT NULL,
[ProductStatusID] INT NOT NULL,
[TypeID] INT NOT NULL,
[ProductImage] VARBINARY(MAX),
PRIMARY KEY ([ProductID])
);