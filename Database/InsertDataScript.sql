USE [CoroNacessitiesDB]
GO

SET IDENTITY_INSERT [dbo].[Address] ON
GO
INSERT [dbo].[Address] ([AddressID],[Address]) VALUES (1, N' West Green Old Freeway')
GO
INSERT [dbo].[Address] ([AddressID],[Address]) VALUES (2, N' East White New Road')
GO
INSERT [dbo].[Address] ([AddressID],[Address]) VALUES (3, N'Fossil SecondJefferson Building')
GO
INSERT [dbo].[Address] ([AddressID],[Address]) VALUES (4, N' West Green First Parkway')
GO
INSERT [dbo].[Address] ([AddressID],[Address]) VALUES (5, N' North Green New Blvd.')
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO

print 'Adress inserts done'

SET IDENTITY_INSERT [dbo].[Product] ON
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[StatusID],[TypeID],[ProductImage]) VALUES (1,1, N'Face Mask', N'Face Mask', N'20.00', 1, 1, N'Image1')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[StatusID],[TypeID],[ProductImage]) VALUES (2,4, N'Hand Sanitizer', N'Hand Sanitizer', N'40.00', 1, 2, N'Image2')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[StatusID],[TypeID],[ProductImage]) VALUES (3,6, N'Surgical Gloves', N'Surgical Gloves', N'22.50', 2, 3, N'Image3')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[StatusID],[TypeID],[ProductImage]) VALUES (4,1, N'Face Shield', N'Face Shield', N'60.00', 1, 1, N'Image4')
GO
INSERT [dbo].[Product] ([ProductID],[UserID],[ProductName],[ProductDescription],[Price],[StatusID],[TypeID],[ProductImage]) VALUES (5,3, N'Latex Gloves', N'Latex Gloves', N'25.00', 1, 3, N'Image5')
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

SET IDENTITY_INSERT [dbo].[Status] ON
GO
INSERT [dbo].[Status] ([StatusID],[StatusName],[StatusDescription]) VALUES (1, N'In Stock', N'This product is currently in stock.')
GO
INSERT [dbo].[Status] ([StatusID],[StatusName],[StatusDescription]) VALUES (2, N'Out of Stock', N'This product is currently out of stock. We apologise for any inconvenience.')
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO

print 'Status inserts done'

SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (1, N'Dirco', N'Dirco', N'Liebenberg', N'Dirco@Liebenberg.co.za',N'0123456789', N'5', N'SomeBlob1', 1)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (2, N'Dylan', N'Dylan', N'Carstens', N'Dylan@Cartstens.co.za', N'1234567890', N'5', N'SomeBlob2', 2)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (3, N'Hannelie', N'Hannelie', N'Van Rensburg', N'Hannelie@jvr.co.za', N'2345678901', N'5', N'SomeBlob3', 3)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (4, N'Keanu', N'Keanu', N'Teixera', N'Keanu@Teixera.co.za', N'3456789012', N'5', N'SomeBlob4', 4)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (5, N'Ronaldo', N'Ronaldo', N'Ronaldo', N'Ronaldo@Ronaldo.co.za', N'4567890123', N'5', N'SomeBlob5', 5)
GO
INSERT [dbo].[Users] ([UserID],[Username],[Name],[Surname],[Email],[ContactNo],[Rating],[PayPalInfo],[AddressID]) VALUES (6, N'Vignesh', N'Vignesh', N'Iyer', N'Vignesh@Iyer.co.za', N'5678901234', N'5', N'SomeBlob6', 6)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

print 'Users inserts done'
