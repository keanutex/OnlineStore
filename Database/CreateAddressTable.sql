DROP TABLE IF EXISTS dbo.Address;
CREATE TABLE CoroNacessitiesDB.dbo.Address
(
    [AddressID] INT IDENTITY(1,1) NOT NULL,
    [ComplexName] VARCHAR(50),
    [UnitNumber] INT,
    [StreetName] VARCHAR(50) NOT NULL,
    [StreetNumber] INT NOT NULL,
    [Suburb] VARCHAR(50) NOT NULL,
    [CityID] INT NOT NULL,
PRIMARY KEY ([AddressID])
);
