CREATE TABLE CoroNacessitiesDB.dbo.Product(
[ProductID] INT IDENTITY(1,1) NOT NULL,
[UserID] INT NOT NULL,
[ProductName] VARCHAR(50) NOT NULL,
[ProductDescription] VARCHAR(250) NOT NULL,
[Price] DECIMAL(10,2) NOT NULL,
[StatusID] INT NOT NULL,
[TypeID] INT NOT NULL,
[ProductImage] VARCHAR(MAX),
PRIMARY KEY ([ProductID])
);