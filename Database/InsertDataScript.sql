USE [CoroNacessitiesDB]
GO

SET IDENTITY_INSERT [dbo].[Address] ON
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (1, NULL, NULL, N' West Green Old Freeway', 49, N'Farnham', 7)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (2, NULL, NULL, N' North Rocky Milton Parkway', 274, N'Dolwyddelan', 3)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (3, NULL, NULL, N' South Green Oak Blvd.', 67, N'Cwmbran', 2)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (4, NULL, NULL, N' East Rocky Nobel Road', 146, N'Moffat', 4)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (5, NULL, NULL, N' East Rocky Hague Road', 237, N'Ipswich', 8)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (6, NULL, NULL, N' West Green First Parkway', 99, N'Walsingham', 6)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (7, NULL, NULL, N' North White Second Avenue', 212, N'Broadstone', 5)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (8, NULL, NULL, N' East White New Road', 130, N'West Kensington', 10)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (9, N'Fossil SecondJefferson Building', 24, N' East Rocky Milton Parkway', 54, N'Malton', 1)
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [CityID]) VALUES (10, N'FabienHamilton Building', 13, N' North Green New Blvd.', 108, N'Boncath', 9)
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO

print 'Adress table inserts done'

SET IDENTITY_INSERT [dbo].[City] ON
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (1, N'31.049999', N'-29.883333', N'Durban')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (2, N'27.865833', N'-26.266111', N'Soweto')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (3, N'26.154898', N'-29.087217', N'Bloemfontein')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (4, N'25.619022', N'-33.958252', N'Port Elizabeth')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (5, N'28.218370', N'-25.731340', N'Pretoria')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (6, N'28.034088', N'-26.195246', N'Johannesburg')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (7, N'25.640181', N'-25.853161', N'Mahikeng')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (8, N'29.255323', N'-25.872782', N'Emalahleni')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (9, N'27.901464', N'-26.120134', N'Roodepoort')
GO
INSERT [dbo].[City] ([CityID], [Longitude], [Latitude], [CityName]) VALUES (10, N'22.457581', N'-33.977074', N'George')
GO
SET IDENTITY_INSERT [dbo].[City] OFF
GO

print 'City table inserts done'

SET IDENTITY_INSERT [dbo].[Product] ON
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (1,1, N'Face Mask', N'Face Mask', N'20.00', 1, 1, 0)
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (2,4, N'Hand Sanitizer', N'Hand Sanitizer', N'40.00', 1, 2, 0)
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (3,6, N'Surgical Gloves', N'Surgical Gloves', N'22.50', 2, 3, 0)
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (4,1, N'Face Shield', N'Face Shield', N'60.00', 1, 1, 0)
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (5,3, N'Latex Gloves', N'Latex Gloves', N'25.00', 1, 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

print 'Product table inserts done'

SET IDENTITY_INSERT [dbo].[ProductType] ON
GO
INSERT [dbo].[ProductType] ([TypeID],[TypeName]) VALUES (1, N'Mask')
GO
INSERT [dbo].[ProductType] ([TypeID],[TypeName]) VALUES (2, N'Sanitizer')
GO
INSERT [dbo].[ProductType] ([TypeID],[TypeName]) VALUES (3, N'Gloves')
GO
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO

print 'ProductType table inserts done'

SET IDENTITY_INSERT [dbo].[ProductStatus] ON
GO
INSERT [dbo].[ProductStatus] ([ProductStatusID],[StatusName],[StatusDescription]) VALUES (1, N'In Stock', N'This product is currently in stock.')
GO
INSERT [dbo].[ProductStatus] ([ProductStatusID],[StatusName],[StatusDescription]) VALUES (2, N'Out of Stock', N'This product is currently out of stock. We apologise for any inconvenience.')
GO
SET IDENTITY_INSERT [dbo].[ProductStatus] OFF
GO

print 'ProductStatus table inserts done'

SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatusID]) VALUES (1, 1, 2)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatusID]) VALUES (2, 1, 2)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatusID]) VALUES (3, 2, 3)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatusID]) VALUES (4, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO

print 'Orders table inserts done'


SET IDENTITY_INSERT [dbo].[OrderItem] ON 
GO
INSERT [dbo].[OrderItem] ([OrderItemID], [OrderID], [ProductID], [NoOfProducts]) VALUES (1, 1, 2, 1)
GO
INSERT [dbo].[OrderItem] ([OrderItemID], [OrderID], [ProductID], [NoOfProducts]) VALUES (2, 1, 2, 5)
GO
INSERT [dbo].[OrderItem] ([OrderItemID], [OrderID], [ProductID], [NoOfProducts]) VALUES (3, 2, 4, 2)
GO
INSERT [dbo].[OrderItem] ([OrderItemID], [OrderID], [ProductID], [NoOfProducts]) VALUES (4, 3, 5, 6)
GO
INSERT [dbo].[OrderItem] ([OrderItemID], [OrderID], [ProductID], [NoOfProducts]) VALUES (5, 3, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO

print 'OrderItem table inserts done'


SET IDENTITY_INSERT [dbo].[OrderStatus] ON 
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusDescription]) VALUES (1, N'Cancelled')
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusDescription]) VALUES (2, N'Payment Received')
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusDescription]) VALUES (3, N'Accepted')
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusDescription]) VALUES (4, N'Completed')
GO
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusDescription]) VALUES (5, N'In-Progress')
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO

print 'OrderStatus table inserts done'

SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[AddressID],[Password]) VALUES (1, N'Dirco', N'Dirco', N'Liebenberg', N'Dirco@Liebenberg.co.za',N'0123456789', 1, N'd03oFC8TbZLFiIhlnUJ5+1W8aLfWql9fyvmBm1Ye+7k=')
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[AddressID],[Password]) VALUES (2, N'Dylan', N'Dylan', N'Carstens', N'Dylan@Cartstens.co.za', N'1234567890', 2, N'd03oFC8TbZLFiIhlnUJ5+1W8aLfWql9fyvmBm1Ye+7k=')
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[AddressID],[Password]) VALUES (3, N'Hannelie', N'Hannelie', N'Van Rensburg', N'Hannelie@jvr.co.za', N'2345678901', 3, N'd03oFC8TbZLFiIhlnUJ5+1W8aLfWql9fyvmBm1Ye+7k=')
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[AddressID],[Password]) VALUES (4, N'Keanu', N'Keanu', N'Teixera', N'Keanu@Teixera.co.za', N'3456789012', 4, N'd03oFC8TbZLFiIhlnUJ5+1W8aLfWql9fyvmBm1Ye+7k=')
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[AddressID],[Password]) VALUES (5, N'Ronaldo', N'Ronaldo', N'Ronaldo', N'Ronaldo@Ronaldo.co.za', N'4567890123', 5, N'd03oFC8TbZLFiIhlnUJ5+1W8aLfWql9fyvmBm1Ye+7k=')
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[AddressID],[Password]) VALUES (6, N'Vignesh', N'Vignesh', N'Iyer', N'Vignesh@Iyer.co.za', N'5678901234', 6, N'd03oFC8TbZLFiIhlnUJ5+1W8aLfWql9fyvmBm1Ye+7k=')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

print 'Users table inserts done'
