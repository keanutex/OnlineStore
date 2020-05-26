DROP TABLE IF EXISTS CoroNacessitiesDB.dbo.City;
--Create City table
CREATE TABLE CoroNacessitiesDB.dbo.City(
[CityID] INT IDENTITY(1,1) NOT NULL,
[Longitude] VARCHAR(50)NOT NULL,
[Latitude] VARCHAR(50) NOT NULL,
[CityName] VARCHAR(50) NOT NULL,
PRIMARY KEY ([CityID])
);