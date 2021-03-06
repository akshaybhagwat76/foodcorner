USE [master]
GO
/****** Object:  Database [RestaurantDB]    Script Date: 09/05/2017 17:22:02 ******/
CREATE DATABASE [RestaurantDB] ON  PRIMARY 
( NAME = N'Restuarant', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RestaurantDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Restuarant_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RestaurantDB_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RestaurantDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [RestaurantDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [RestaurantDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [RestaurantDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [RestaurantDB] SET ARITHABORT OFF
GO
ALTER DATABASE [RestaurantDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [RestaurantDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [RestaurantDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [RestaurantDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [RestaurantDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [RestaurantDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [RestaurantDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [RestaurantDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [RestaurantDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [RestaurantDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [RestaurantDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [RestaurantDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [RestaurantDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [RestaurantDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [RestaurantDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [RestaurantDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [RestaurantDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [RestaurantDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [RestaurantDB] SET  READ_WRITE
GO
ALTER DATABASE [RestaurantDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [RestaurantDB] SET  MULTI_USER
GO
ALTER DATABASE [RestaurantDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [RestaurantDB] SET DB_CHAINING OFF
GO
USE [RestaurantDB]
GO
/****** Object:  Table [dbo].[tblRestuarantRegistration]    Script Date: 09/05/2017 17:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRestuarantRegistration](
	[r_id] [int] IDENTITY(1,1) NOT NULL,
	[r_name] [varchar](max) NULL,
	[r_mobileno] [varchar](max) NULL,
	[r_emailid] [varchar](max) NULL,
	[r_address] [varchar](max) NULL,
	[r_description] [varchar](max) NULL,
	[r_status] [varchar](max) NULL,
	[rest_image] [varchar](max) NULL,
	[r_pwd] [varchar](max) NULL,
	[r_lastdate] [date] NULL,
 CONSTRAINT [PK_tblRestuarantRegistration] PRIMARY KEY CLUSTERED 
(
	[r_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblRestuarantRegistration] ON
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (28, N'Cowboyz', N'0261585685', N'r@gmail.com', N'Udhna', N'this is vegiterian', N'blocked', N'5.jpg', N'a', NULL)
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (29, N'Cowboyz', N'0261585685', N'r1@gmail.com', N'SUrat', N'this is vegiterian', N'Approve', N'pl2.png', N'a', NULL)
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (30, N'savera', N'a', N'q@gmail.com', N'a', N'a', N'Pending', N'co4.jpg', N'a', NULL)
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (31, N'fas', N'nj', N'manoj@gmail.com', N'k', N'njk', N'Approve', N'co4.jpg', N'njk', NULL)
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (32, N'dasd', N'njk', N'n@gmail.com', N'njk', N'njk', N'Pending', N'cakes.jpg', N'njk', NULL)
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (33, N'fda', N'njk', N'n1@gmail.com', N'nj', N'k', N'Pending', N'BREAKFAST.jpg', N'fas', NULL)
INSERT [dbo].[tblRestuarantRegistration] ([r_id], [r_name], [r_mobileno], [r_emailid], [r_address], [r_description], [r_status], [rest_image], [r_pwd], [r_lastdate]) VALUES (34, N'savera2', N'1561', N'p@gmail.com', N'surat', N'lkdjfk', N'blocked', N'BREAKFAST.jpg', N'123456789', NULL)
SET IDENTITY_INSERT [dbo].[tblRestuarantRegistration] OFF
/****** Object:  Table [dbo].[tblPayment]    Script Date: 09/05/2017 17:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPayment](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[payment_mode] [varchar](max) NULL,
	[payment_status] [varchar](max) NULL,
	[total_amount] [numeric](18, 0) NULL,
	[payment_date] [datetime] NULL,
 CONSTRAINT [PK_tblPayment] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblPayment] ON
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (1, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A76701765F0E AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (2, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A7670176790E AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (3, 401, N'Cash', N'Complete', CAST(800 AS Numeric(18, 0)), CAST(0x0000A767017A175A AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (4, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A767017B0C11 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (5, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A7670189E366 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (6, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A767018A0793 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (7, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A767018A234C AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (8, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A767018ABA46 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (9, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A767018B1D9B AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (10, 401, N'Cheque', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A767018B6640 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (11, 401, N'Cheque', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A76800006C6C AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (12, 401, N'Cheque', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A7680000D9A6 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (13, 401, N'Cheque', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A7680000F0AD AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (14, 401, N'Cash', N'Complete', CAST(500 AS Numeric(18, 0)), CAST(0x0000A76800010B17 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (15, 401, N'Cash', N'Complete', CAST(1350 AS Numeric(18, 0)), CAST(0x0000A768007FD1B0 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (16, 401, N'Cash', N'Complete', CAST(9000 AS Numeric(18, 0)), CAST(0x0000A768009D8398 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (17, 401, N'Cash', N'Complete', CAST(3150 AS Numeric(18, 0)), CAST(0x0000A768009DC6F2 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (18, 401, N'Cash', N'Complete', CAST(4050 AS Numeric(18, 0)), CAST(0x0000A768009E9596 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (19, 401, N'Cash', N'Complete', CAST(8550 AS Numeric(18, 0)), CAST(0x0000A768009EEC6B AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (20, 401, N'Cash', N'Complete', CAST(450 AS Numeric(18, 0)), CAST(0x0000A76800B680CB AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (21, 401, N'Cash', N'Complete', CAST(450 AS Numeric(18, 0)), CAST(0x0000A76800B959E6 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (22, 401, N'Cash', N'Complete', CAST(150 AS Numeric(18, 0)), CAST(0x0000A76800BAD0FB AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (23, 401, N'Cash', N'Complete', CAST(450 AS Numeric(18, 0)), CAST(0x0000A76800BFBBCD AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (24, 403, N'Cash', N'Complete', CAST(450 AS Numeric(18, 0)), CAST(0x0000A76800C07034 AS DateTime))
INSERT [dbo].[tblPayment] ([payment_id], [order_id], [payment_mode], [payment_status], [total_amount], [payment_date]) VALUES (25, 404, N'Cash', N'Complete', CAST(2250 AS Numeric(18, 0)), CAST(0x0000A7E200F283FF AS DateTime))
SET IDENTITY_INSERT [dbo].[tblPayment] OFF
/****** Object:  Table [dbo].[tblOrders]    Script Date: 09/05/2017 17:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrders](
	[serial_no] [int] IDENTITY(1,1) NOT NULL,
	[o_id] [int] NULL,
	[f_id] [int] NULL,
	[o_userid] [int] NULL,
	[o_quantity] [varchar](max) NULL,
	[o_date] [date] NULL,
	[o_status] [varchar](max) NULL,
	[o_price] [int] NULL,
	[r_id] [int] NULL,
	[offer_id] [int] NULL,
	[address] [varchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblOrders_1] PRIMARY KEY CLUSTERED 
(
	[serial_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblOrders] ON
INSERT [dbo].[tblOrders] ([serial_no], [o_id], [f_id], [o_userid], [o_quantity], [o_date], [o_status], [o_price], [r_id], [offer_id], [address], [mobile]) VALUES (22, 401, 3, 9, N'1', CAST(0xC33C0B00 AS Date), N'Delivered', 150, 34, NULL, N'surat', N'7383328380')
INSERT [dbo].[tblOrders] ([serial_no], [o_id], [f_id], [o_userid], [o_quantity], [o_date], [o_status], [o_price], [r_id], [offer_id], [address], [mobile]) VALUES (23, 402, 2, 9, N'1', CAST(0xC33C0B00 AS Date), N'Delivered', 450, 29, NULL, N'surat', N'7383328380')
INSERT [dbo].[tblOrders] ([serial_no], [o_id], [f_id], [o_userid], [o_quantity], [o_date], [o_status], [o_price], [r_id], [offer_id], [address], [mobile]) VALUES (24, 403, 2, 11, N'1', CAST(0xC33C0B00 AS Date), N'Pending', 450, 29, NULL, N'udhna', N'7048729059')
INSERT [dbo].[tblOrders] ([serial_no], [o_id], [f_id], [o_userid], [o_quantity], [o_date], [o_status], [o_price], [r_id], [offer_id], [address], [mobile]) VALUES (25, 404, 2, 17, N'5', CAST(0x3D3D0B00 AS Date), N'Pending', 2250, 29, NULL, N'surat', N'946478954')
SET IDENTITY_INSERT [dbo].[tblOrders] OFF
/****** Object:  Table [dbo].[tblFoods]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblFoods](
	[f_id] [int] IDENTITY(1,1) NOT NULL,
	[f_name] [varchar](max) NULL,
	[c_id] [int] NULL,
	[s_id] [int] NULL,
	[f_price] [int] NULL,
	[f_date] [date] NULL,
	[f_image] [varchar](max) NULL,
	[f_description] [varchar](max) NULL,
	[r_id] [int] NULL,
	[f_status] [int] NULL,
	[offer_id] [int] NULL,
 CONSTRAINT [PK_tblFoods] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblFoods] ON
INSERT [dbo].[tblFoods] ([f_id], [f_name], [c_id], [s_id], [f_price], [f_date], [f_image], [f_description], [r_id], [f_status], [offer_id]) VALUES (2, N'BURGER', 1, NULL, 450, NULL, N'fp3.png', N'THIS IS BURGER', 29, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblFoods] OFF
/****** Object:  Table [dbo].[tblDeliveryboy]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDeliveryboy](
	[db_id] [int] IDENTITY(1,1) NOT NULL,
	[db_name] [varchar](max) NULL,
	[db_mobile] [varchar](max) NULL,
	[r_id] [int] NULL,
	[db_status] [varchar](max) NULL,
 CONSTRAINT [PK_tblDeliveryboy] PRIMARY KEY CLUSTERED 
(
	[db_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblDeliveryboy] ON
INSERT [dbo].[tblDeliveryboy] ([db_id], [db_name], [db_mobile], [r_id], [db_status]) VALUES (1, N'jayesh', N'738332868', 16, N'Pending')
INSERT [dbo].[tblDeliveryboy] ([db_id], [db_name], [db_mobile], [r_id], [db_status]) VALUES (2, N'bhushan', N'9574896951', 22, N'Pending')
INSERT [dbo].[tblDeliveryboy] ([db_id], [db_name], [db_mobile], [r_id], [db_status]) VALUES (3, N'jatin', N'7895463215', 22, N'Pending')
INSERT [dbo].[tblDeliveryboy] ([db_id], [db_name], [db_mobile], [r_id], [db_status]) VALUES (4, N'anand', N'4444444444', 26, N'Pending')
SET IDENTITY_INSERT [dbo].[tblDeliveryboy] OFF
/****** Object:  Table [dbo].[tblCity]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[s_id] [int] NULL,
	[c_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblCity] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategory](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](max) NULL,
	[category_code] [varchar](max) NULL,
	[category_image] [varchar](max) NULL,
	[category_price] [varchar](max) NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON
INSERT [dbo].[tblCategory] ([c_id], [category_name], [category_code], [category_image], [category_price]) VALUES (1, N'BREAKFAST', N'B101', N'BREAKFAST.jpg', N'1')
INSERT [dbo].[tblCategory] ([c_id], [category_name], [category_code], [category_image], [category_price]) VALUES (2, N'LUNCH', N'L101', N'lunch.jpg', N'1')
INSERT [dbo].[tblCategory] ([c_id], [category_name], [category_code], [category_image], [category_price]) VALUES (3, N'DINNER', N'D101', N'so3.png', N'1')
INSERT [dbo].[tblCategory] ([c_id], [category_name], [category_code], [category_image], [category_price]) VALUES (4, N'DESSERTS', N'DS101', N'p6.jpg', N'1')
INSERT [dbo].[tblCategory] ([c_id], [category_name], [category_code], [category_image], [category_price]) VALUES (5, N'ICE CREAM', N'I101', N'coupon1.jpg', N'1')
INSERT [dbo].[tblCategory] ([c_id], [category_name], [category_code], [category_image], [category_price]) VALUES (6, N'DINNER', N'B2', N'co6.png', N'200')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
/****** Object:  Table [dbo].[tblCart]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCart](
	[cart_id] [int] IDENTITY(1,1) NOT NULL,
	[s_id] [int] NULL,
	[c_id] [int] NULL,
	[qty] [float] NULL,
	[o_id] [int] NULL,
	[amt] [float] NULL,
	[user_id] [int] NULL,
	[f_id] [int] NULL,
 CONSTRAINT [PK_tblCart] PRIMARY KEY CLUSTERED 
(
	[cart_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCart] ON
INSERT [dbo].[tblCart] ([cart_id], [s_id], [c_id], [qty], [o_id], [amt], [user_id], [f_id]) VALUES (407, NULL, NULL, 1, NULL, 700, 8, 29)
SET IDENTITY_INSERT [dbo].[tblCart] OFF
/****** Object:  Table [dbo].[tblBuynow]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBuynow](
	[buy_id] [int] IDENTITY(1,1) NOT NULL,
	[f_id] [int] NULL,
	[qty] [float] NULL,
	[o_id] [int] NULL,
	[amt] [float] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tblBuynow] PRIMARY KEY CLUSTERED 
(
	[buy_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblArea]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArea](
	[a_id] [int] IDENTITY(1,1) NOT NULL,
	[c_id] [int] NULL,
	[s_id] [int] NULL,
	[a_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblArea] PRIMARY KEY CLUSTERED 
(
	[a_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[a_name] [varchar](max) NULL,
	[a_email] [varchar](max) NULL,
	[a_password] [varchar](max) NULL,
	[a_address] [varchar](max) NULL,
	[a_mobile] [varchar](max) NULL,
	[a_photo] [image] NULL,
 CONSTRAINT [PK_tblAdmin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsers](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](max) NULL,
	[user_mobile] [varchar](max) NULL,
	[user_email] [varchar](max) NULL,
	[user_address] [varchar](max) NULL,
	[user_status] [varchar](max) NULL,
	[user_pwd] [varchar](max) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblUsers] ON
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (2, N'njkn', N'kjn', N'jkn', N'nnk', N'njk', N'njk')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (3, N'q', N'8', N'anand@gmail.com', N'9', NULL, N'a')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (4, N'fabshj', N'bhjb', N'akshay@gmail.com', N'hj', NULL, N'619619')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (5, N'fashfaa', N'bfhjfh', N'akshay@gmail.com', N'bjhdf', NULL, N'fjdshba')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (6, N'Manoj Nipane', N'7534564164564', N'manoj@gmail.com', N'asasas', N'Pending', N'704')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (7, N'demo1', N'7252352352', N'd@gmail.com', N'surat', N'Pending', N'a')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (8, N'User1', N'7383328380', N'u@gmail.com', N'surat', N'Pending', N'a')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (9, N'akshay', N'7383328380', N'a@gmail.com', N'surat', N'Pending', N'a')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (10, N'manoj', N'1234567899', N'mm@gmail.com', N'surat', N'Pending', N'm')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (11, N'MANOJ', N'7048729059', N'manojnipane342@gmail.com', N'udhna', N'Pending', N'a')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (15, NULL, NULL, NULL, NULL, N'Pending', NULL)
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (16, N'akshay', N'7383328380', N'akshaybhagwat76@gmail.com', N'surat', N'Pending', N'bb')
INSERT [dbo].[tblUsers] ([user_id], [user_name], [user_mobile], [user_email], [user_address], [user_status], [user_pwd]) VALUES (17, N'Shivam Jaiswal', N'7383312354', N'shivam@gmail.com', N'bihar', N'Pending', N'aa')
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
/****** Object:  Table [dbo].[tblSubcategory]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSubcategory](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[subcategory_name] [varchar](max) NULL,
	[subcategory_code] [varchar](max) NULL,
	[subcategory_image] [varchar](max) NULL,
	[subcategory_price] [varchar](max) NULL,
	[c_id] [int] NULL,
 CONSTRAINT [PK_tblSubcategory] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblSubcategory] ON
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (1, N'BURGER2', N' B2', N'fp3.png', N'500', 15)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (2, N'PIZZA1', N'P1', N'p2.jpg', N'150', 1)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (3, N'PIZZA2', N'P101', N'p5.jpg', N'100', 1)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (4, N'BURGER1', N'b1', N'fp6.png', N'440', 2)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (5, N'BURGER2', N'B2', N'fp3.png', N'160', 2)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (8, N'ice1', N's1', N'co5.png', N'120', 5)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (9, N'ice2', N's2', N'p3.jpg', N'150', 5)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (10, N'Dessert1', N'd1', N'co3.jpg', N'500', 4)
INSERT [dbo].[tblSubcategory] ([s_id], [subcategory_name], [subcategory_code], [subcategory_image], [subcategory_price], [c_id]) VALUES (11, N'Dessert2', N'd2', N'so3.png', N'130', 4)
SET IDENTITY_INSERT [dbo].[tblSubcategory] OFF
/****** Object:  Table [dbo].[tblState]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblState](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSpecials]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSpecials](
	[offer_id] [int] IDENTITY(1,1) NOT NULL,
	[offer_image] [nvarchar](max) NULL,
	[c_id] [int] NULL,
	[r_id] [int] NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[status] [nvarchar](max) NULL,
	[offer_price] [numeric](18, 0) NULL,
	[offer_desc] [nvarchar](max) NULL,
	[f_name] [nvarchar](max) NULL,
	[offer_name] [nvarchar](max) NULL,
	[oldprice] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblSpecials] PRIMARY KEY CLUSTERED 
(
	[offer_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblReviews]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblReviews](
	[review_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[r_id] [int] NULL,
	[description] [varchar](max) NULL,
	[rating] [float] NULL,
 CONSTRAINT [PK_tblReviews] PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblDeliveryAssign]    Script Date: 09/05/2017 17:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDeliveryAssign](
	[assignid] [int] IDENTITY(1,1) NOT NULL,
	[orderid] [int] NULL,
	[db_id] [int] NULL,
	[r_id] [int] NULL,
	[da_date] [date] NULL,
 CONSTRAINT [PK_tblDeliveryAssign] PRIMARY KEY CLUSTERED 
(
	[assignid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblDeliveryAssign] ON
INSERT [dbo].[tblDeliveryAssign] ([assignid], [orderid], [db_id], [r_id], [da_date]) VALUES (1, 402, 2, 28, CAST(0xC23C0B00 AS Date))
INSERT [dbo].[tblDeliveryAssign] ([assignid], [orderid], [db_id], [r_id], [da_date]) VALUES (2, 401, 2, 34, CAST(0xC33C0B00 AS Date))
INSERT [dbo].[tblDeliveryAssign] ([assignid], [orderid], [db_id], [r_id], [da_date]) VALUES (3, 402, 1, 34, CAST(0xC33C0B00 AS Date))
SET IDENTITY_INSERT [dbo].[tblDeliveryAssign] OFF
/****** Object:  ForeignKey [FK_tblReviews_tblRestuarantRegistration]    Script Date: 09/05/2017 17:22:04 ******/
ALTER TABLE [dbo].[tblReviews]  WITH CHECK ADD  CONSTRAINT [FK_tblReviews_tblRestuarantRegistration] FOREIGN KEY([r_id])
REFERENCES [dbo].[tblRestuarantRegistration] ([r_id])
GO
ALTER TABLE [dbo].[tblReviews] CHECK CONSTRAINT [FK_tblReviews_tblRestuarantRegistration]
GO
/****** Object:  ForeignKey [FK_tblReviews_tblUsers]    Script Date: 09/05/2017 17:22:04 ******/
ALTER TABLE [dbo].[tblReviews]  WITH CHECK ADD  CONSTRAINT [FK_tblReviews_tblUsers] FOREIGN KEY([user_id])
REFERENCES [dbo].[tblUsers] ([user_id])
GO
ALTER TABLE [dbo].[tblReviews] CHECK CONSTRAINT [FK_tblReviews_tblUsers]
GO
/****** Object:  ForeignKey [FK_tblDeliveryAssign_tblDeliveryboy]    Script Date: 09/05/2017 17:22:04 ******/
ALTER TABLE [dbo].[tblDeliveryAssign]  WITH CHECK ADD  CONSTRAINT [FK_tblDeliveryAssign_tblDeliveryboy] FOREIGN KEY([db_id])
REFERENCES [dbo].[tblDeliveryboy] ([db_id])
GO
ALTER TABLE [dbo].[tblDeliveryAssign] CHECK CONSTRAINT [FK_tblDeliveryAssign_tblDeliveryboy]
GO
/****** Object:  ForeignKey [FK_tblDeliveryAssign_tblRestuarantRegistration]    Script Date: 09/05/2017 17:22:04 ******/
ALTER TABLE [dbo].[tblDeliveryAssign]  WITH CHECK ADD  CONSTRAINT [FK_tblDeliveryAssign_tblRestuarantRegistration] FOREIGN KEY([r_id])
REFERENCES [dbo].[tblRestuarantRegistration] ([r_id])
GO
ALTER TABLE [dbo].[tblDeliveryAssign] CHECK CONSTRAINT [FK_tblDeliveryAssign_tblRestuarantRegistration]
GO
