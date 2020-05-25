DROP TABLE IF EXISTS dbo.ProductStatus;
CREATE TABLE CoroNacessitiesDB.dbo.ProductStatus(
[ProductStatusID] INT IDENTITY(1,1) NOT NULL,
[StatusName] VARCHAR(50) NOT NULL,
[StatusDescription] VARCHAR(150) NOT NULL,
PRIMARY KEY ([ProductStatusID])
);