DROP TABLE IF EXISTS dbo.Address;
CREATE TABLE CoroNacessitiesDB.dbo.Address
(
    [AddressID] BIGINT NOT NULL IDENTITY,
    [ComplexName] VARCHAR(50),
    [UnitNumber] SMALLINT,
    [StreetName] VARCHAR(50) NOT NULL,
    [StreetNumber] SMALLINT NOT NULL,
    [Suburb] VARCHAR(50) NOT NULL,
    [City] VARCHAR(50) NOT NULL,
    [Province] VARCHAR(50) NOT NULL,
    [Country] VARCHAR(50) NOT NULL
);
