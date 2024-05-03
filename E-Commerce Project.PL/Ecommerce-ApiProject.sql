create   database EcommerceProject

/****** Object:  Table [dbo].[Cart]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [varchar](100) NOT NULL,
	[CatImage] [varchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Subject] [varchar](100) NULL,
	[Message] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[Status] [varchar](50) NULL,
	[OrderDate] [datetime] NOT NULL,
	[IsCancel] [bit] NOT NULL,
	[PaymentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CardNo] [int] NULL,
	[ExpDate] [nvarchar](50) NULL,
	[CVVNo] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[PaymentMode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProdId] [int] IDENTITY(1,1) NOT NULL,
	[ProdName] [varchar](100) NOT NULL,
	[ShortDesc] [varchar](200) NULL,
	[LongDesc] [varchar](max) NULL,
	[AdditionalDesc] [varchar](max) NULL,
	[Color] [varchar](30) NULL,
	[Size] [varchar](30) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[CatId] [int] NOT NULL,
	[SubCatId] [int] NOT NULL,
	[Sold] [int] NULL,
	[IsCustomized] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [varchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[DefaultImg] [bit] NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReview]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReview](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [int] NOT NULL,
	[Comment] [varchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductReview] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[SubCatId] [int] IDENTITY(1,1) NOT NULL,
	[SubCatName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[FullName] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Mobile] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Password] [varchar](50) NULL,
	[Image] [varchar](50) NULL,
	[RoleId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 4/29/2024 3:40:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishList](
	[WishLstId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED 
(
	[WishLstId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProdId])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Order] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payment] ([PaymentId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Order]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProdId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProdId])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProdId])
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_Product]
GO
ALTER TABLE [dbo].[ProductReview]  WITH CHECK ADD  CONSTRAINT [FK_ProductReview_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ProductReview] CHECK CONSTRAINT [FK_ProductReview_User]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_SubCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CatId])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_SubCategory]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_User]
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_WishList] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProdId])
GO
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_WishList]
GO
