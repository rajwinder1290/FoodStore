INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c5ef7d14-da7f-4049-9dc2-9db3bd5448ca', N'power', N'power', N'375cadc9-ed95-4227-b09d-2cedc846b402')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3d607809-cda9-4d2b-ac26-76eb1db07491', N'admin@foodstore.com', N'ADMIN@FOODSTORE.COM', N'admin@foodstore.com', N'ADMIN@FOODSTORE.COM', 1, N'AQAAAAEAACcQAAAAEGXcOCEoKYdX0TWjd0vn6haSfiPy1TaAH2OhvtmiipP9oL3RxOMY05RX0LdIHeNVeg==', N'3GGRINAVI6EW6NFMDB2VI3GHVYRUHC6B', N'668bf632-efa7-4394-b2de-a3165c178dfd', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8bf75fca-1bec-49f0-8631-91b0592e5194', N'jonsnow@gmail.com', N'JONSNOW@GMAIL.COM', N'jonsnow@gmail.com', N'JONSNOW@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAELU9PiZJXZAx8DC3mA0iDqry/+wEkgNBFfpPBHDWbghKcYOmpR0GDIR/gvQ39uxRwA==', N'7MK47QHSDEVXOXAL3ALXJSMVLH6HTF5G', N'db02220d-0652-4193-bd4e-a0bb15a67498', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d607809-cda9-4d2b-ac26-76eb1db07491', N'c5ef7d14-da7f-4049-9dc2-9db3bd5448ca')
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (1, N'Thomas Exports')
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (2, N'Lizaz Foods')
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (3, N'McCain')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategories] ON 
GO
INSERT [dbo].[FoodCategories] ([CategoryID], [CategoryName]) VALUES (1, N'Fish')
GO
INSERT [dbo].[FoodCategories] ([CategoryID], [CategoryName]) VALUES (2, N'Peas')
GO
INSERT [dbo].[FoodCategories] ([CategoryID], [CategoryName]) VALUES (3, N'Sweet Corn')
GO
INSERT [dbo].[FoodCategories] ([CategoryID], [CategoryName]) VALUES (4, N'Cheesey')
GO
INSERT [dbo].[FoodCategories] ([CategoryID], [CategoryName]) VALUES (5, N'Potato')
GO
SET IDENTITY_INSERT [dbo].[FoodCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodInfos] ON 
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (1, N'Potato Cheese Shotz', N'Potato layer fill with cheese with 1 kg packing', N'.png', 25, 3, 4)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (2, N'Tasty Chilli Cheesy Nuggets', N'Cheesy Nuggets with Chilli Flavour', N'.png', 35, 3, 4)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (3, N'Veggie Nuggets', N'Nuggets with Veggie in 1 KG', N'.png', 30, 3, 5)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (4, N'Aloo Tikki', N'Ready to serve Aloo Tikki It serve 10 Aloo Tikki', N'.png', 33, 3, 5)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (5, N'Frozen Brine Shrimp Cube', N'TRAYS 7 X 3.5 OZ CUBE TRAY 1 BOX', N'.jpg', 10.15, 1, 1)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (6, N'Frozen Krill Pacifica Flat', N'10 X 16 OZ', N'.jpg', 69.95, 1, 1)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (7, N'Frozen Brine Shrimp Flat', N'PACKS, 5 X 1 KG. ', N'.jpg', 60, 2, 1)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (8, N'Del Monte Whole Corn', N'Kernels, 420g', N'.jpg', 35, 2, 3)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (9, N'Frozen Green Peas With Slider Zip Standy Pouch', N'500 gm pouch', N'.jpg', 16, 2, 2)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (10, N'Frozen Vegetables - Green Peas', N'1KG PACK', N'.jpg', 36, 2, 2)
GO
INSERT [dbo].[FoodInfos] ([FoodID], [FoodName], [Description], [Extension], [Price], [CompanyID], [CategoryID]) VALUES (11, N'American Sweet Corn', N'1KG Pack', N'.jpg', 45, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[FoodInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodOrders] ON 
GO
INSERT [dbo].[FoodOrders] ([OrderID], [Description], [OrderDate], [UserID], [Quantity], [Price], [Total], [FoodID]) VALUES (1, N'I need urgently', CAST(N'2021-10-10T09:26:24.3644842' AS DateTime2), N'jonsnow@gmail.com', 10, 25, 250, 3)
GO
INSERT [dbo].[FoodOrders] ([OrderID], [Description], [OrderDate], [UserID], [Quantity], [Price], [Total], [FoodID]) VALUES (2, N'Good Quality Need', CAST(N'2021-10-10T09:27:00.5684207' AS DateTime2), N'jonsnow@gmail.com', 10, 60, 600, 7)
GO
SET IDENTITY_INSERT [dbo].[FoodOrders] OFF
GO
