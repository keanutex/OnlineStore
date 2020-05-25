USE [CoroNacessitiesDB]
GO

SET IDENTITY_INSERT [dbo].[Address] ON
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (1, NULL, NULL, N' West Green Old Freeway', 49, N'Farnham', N'Montgomery', N'Northern Cape', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (2, NULL, NULL, N' North Rocky Milton Parkway', 274, N'Dolwyddelan', N'St. Paul', N'North West', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (3, NULL, NULL, N' South Green Oak Blvd.', 67, N'Cwmbran', N'Bakersfield', N'KwaZulu Natal', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (4, NULL, NULL, N' East Rocky Nobel Road', 146, N'Moffat', N'Yonkers', N'Free State', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (5, NULL, NULL, N' East Rocky Hague Road', 237, N'Ipswich', N'Glendale', N'Western Cape', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (6, NULL, NULL, N' West Green First Parkway', 99, N'Walsingham', N'Des Moines', N'Limpopo', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (7, NULL, NULL, N' North White Second Avenue', 212, N'Broadstone', N'Anaheim', N'Eastern Cape', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (8, NULL, NULL, N' East White New Road', 130, N'West Kensington', N'Cincinnati', N'Western Cape', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (9, N'Fossil SecondJefferson Building', 24, N' East Rocky Milton Parkway', 54, N'Malton', N'Aurora', N'Eastern Cape', N'South Africa ')
GO
INSERT [dbo].[Address] ([AddressID], [ComplexName], [UnitNumber], [StreetName], [StreetNumber], [Suburb], [City], [Province], [Country]) VALUES (10, N'FabienHamilton Building', 13, N' North Green New Blvd.', 108, N'Boncath', N'Omaha', N'KwaZulu Natal', N'South Africa ')
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO

print 'Adress inserts done'

SET IDENTITY_INSERT [dbo].[Product] ON
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (1,1, N'Face Mask', N'Face Mask', N'20.00', 1, 1, N'Image1')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (2,4, N'Hand Sanitizer', N'Hand Sanitizer', N'40.00', 1, 2, N'Image2')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (3,6, N'Surgical Gloves', N'Surgical Gloves', N'22.50', 2, 3, N'Image3')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (4,1, N'Face Shield', N'Face Shield', N'60.00', 1, 1, N'Image4')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[ProductStatusID],[TypeID],[ProductImage]) VALUES (5,3, N'Latex Gloves', N'Latex Gloves', N'25.00', 1, 3, N'Image5')
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

print 'Product inserts done'

SET IDENTITY_INSERT [dbo].[ProductType] ON
GO
INSERT [dbo].[ProductType] ([TypeID],[UserID],[TypeName]) VALUES (1, 1, N'Mask')
GO
INSERT [dbo].[ProductType] ([TypeID],[UserID],[TypeName]) VALUES (2, 1, N'Sanitizer')
GO
INSERT [dbo].[ProductType] ([TypeID],[UserID],[TypeName]) VALUES (3, 3, N'Gloves')
GO
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO

print 'ProductType inserts done'

SET IDENTITY_INSERT [dbo].[ProductStatus] ON
GO
INSERT [dbo].[ProductStatus] ([ProductStatusID],[StatusName],[StatusDescription]) VALUES (1, N'In Stock', N'This product is currently in stock.')
GO
INSERT [dbo].[ProductStatus] ([ProductStatusID],[StatusName],[StatusDescription]) VALUES (2, N'Out of Stock', N'This product is currently out of stock. We apologise for any inconvenience.')
GO
SET IDENTITY_INSERT [dbo].[ProductStatus] OFF
GO

print 'ProductStatus inserts done'

SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([EntryIntoTableID], [OrderID], [UserID], [ProductID], [NoOfProducts], [OrderStatusID]) VALUES (1, 1, 1, 2, 5, 2)
GO
INSERT [dbo].[Orders] ([EntryIntoTableID], [OrderID], [UserID], [ProductID], [NoOfProducts], [OrderStatusID]) VALUES (2, 1, 1, 3, 2, 2)
GO
INSERT [dbo].[Orders] ([EntryIntoTableID], [OrderID], [UserID], [ProductID], [NoOfProducts], [OrderStatusID]) VALUES (3, 2, 6, 1, 2, 4)
GO
INSERT [dbo].[Orders] ([EntryIntoTableID], [OrderID], [UserID], [ProductID], [NoOfProducts], [OrderStatusID]) VALUES (4, 3, 4, 1, 1, 5)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO

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

SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (1, N'Dirco', N'Dirco', N'Liebenberg', N'Dirco@Liebenberg.co.za',N'0123456789', N'5', N'Image1', 1)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (2, N'Dylan', N'Dylan', N'Carstens', N'Dylan@Cartstens.co.za', N'1234567890', N'5', N'Image2', 2)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (3, N'Hannelie', N'Hannelie', N'Van Rensburg', N'Hannelie@jvr.co.za', N'2345678901', N'5', N'Image3', 3)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (4, N'Keanu', N'Keanu', N'Teixera', N'Keanu@Teixera.co.za', N'3456789012', N'5', N'Image4', 4)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (5, N'Ronaldo', N'Ronaldo', N'Ronaldo', N'Ronaldo@Ronaldo.co.za', N'4567890123', N'5', N'Image5', 5)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (6, N'Vignesh', N'Vignesh', N'Iyer', N'Vignesh@Iyer.co.za', N'5678901234', N'5', N'Image6', 6)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

print 'Users inserts done'
