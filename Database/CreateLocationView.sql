CREATE VIEW LocationView AS
SELECT        dbo.Users.UserID,dbo.Users.Username, dbo.City.Latitude, dbo.City.Longitude
FROM            dbo.Address INNER JOIN
                         dbo.City ON dbo.Address.CityID = dbo.City.CityID INNER JOIN
                         dbo.Users ON dbo.Address.AddressID = dbo.Users.AddressID
GO