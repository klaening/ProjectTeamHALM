USE [master]
GO
/****** Object:  Database [ToDoApp]    Script Date: 2020-09-11 11:38:10 ******/
CREATE DATABASE [ToDoApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ToDoApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToDoApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ToDoApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ToDoApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToDoApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToDoApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToDoApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToDoApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToDoApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToDoApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToDoApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToDoApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToDoApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToDoApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToDoApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToDoApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToDoApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToDoApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToDoApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToDoApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToDoApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToDoApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToDoApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToDoApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToDoApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToDoApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToDoApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToDoApp] SET RECOVERY FULL 
GO
ALTER DATABASE [ToDoApp] SET  MULTI_USER 
GO
ALTER DATABASE [ToDoApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToDoApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToDoApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToDoApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToDoApp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ToDoApp', N'ON'
GO
ALTER DATABASE [ToDoApp] SET QUERY_STORE = OFF
GO
USE [ToDoApp]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](255) NOT NULL,
	[CustomerAddress] [varchar](255) NOT NULL,
	[CustomerPhoneNo] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[ID] [int] NOT NULL,
	[OrderDescription] [varchar](255) NOT NULL,
	[StartingDate] [date] NOT NULL,
	[Commentary] [varchar](255) NULL,
	[HoursSpent] [decimal](19, 0) NOT NULL,
	[TravelTime] [decimal](19, 0) NULL,
	[ExtraCosts] [decimal](19, 0) NULL,
	[StaffID] [int] NOT NULL,
	[OrderStatusesID] [int] NOT NULL,
	[CustomersID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatuses]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StaffName] [varchar](255) NOT NULL,
	[DepartmentsID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkOrders]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDescription] [varchar](255) NOT NULL,
	[StartingDate] [date] NOT NULL,
	[Commentary] [varchar](255) NULL,
	[HoursSpent] [decimal](19, 0) NOT NULL,
	[TravelTime] [decimal](19, 0) NULL,
	[ExtraCosts] [decimal](19, 0) NULL,
	[StaffID] [int] NOT NULL,
	[OrderStatusesID] [int] NOT NULL,
	[CustomersID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [CustomerName], [CustomerAddress], [CustomerPhoneNo]) VALUES (1, N'Ylvas Yviga Ynglingar AB', N'Ylvägen 12', N'(+46)736271925')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [DepartmentName]) VALUES (1, N'Snickeri')
INSERT [dbo].[Departments] ([ID], [DepartmentName]) VALUES (2, N'Elektronik')
INSERT [dbo].[Departments] ([ID], [DepartmentName]) VALUES (3, N'Mekanik')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
INSERT [dbo].[OrderHistory] ([ID], [OrderDescription], [StartingDate], [Commentary], [HoursSpent], [TravelTime], [ExtraCosts], [StaffID], [OrderStatusesID], [CustomersID]) VALUES (2, N'Kaffemaskinen kan inte göra varm choklad', CAST(N'2020-09-10' AS Date), N'Choklad, mums!', CAST(6 AS Decimal(19, 0)), CAST(4 AS Decimal(19, 0)), CAST(30 AS Decimal(19, 0)), 3, 5, 1)
GO
SET IDENTITY_INSERT [dbo].[OrderStatuses] ON 

INSERT [dbo].[OrderStatuses] ([ID], [StatusName]) VALUES (1, N'Pending')
INSERT [dbo].[OrderStatuses] ([ID], [StatusName]) VALUES (2, N'Accepted')
INSERT [dbo].[OrderStatuses] ([ID], [StatusName]) VALUES (3, N'Denied')
INSERT [dbo].[OrderStatuses] ([ID], [StatusName]) VALUES (4, N'Review')
INSERT [dbo].[OrderStatuses] ([ID], [StatusName]) VALUES (5, N'Completed')
SET IDENTITY_INSERT [dbo].[OrderStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([ID], [StaffName], [DepartmentsID]) VALUES (1, N'Rolf Johansson', 1)
INSERT [dbo].[Staff] ([ID], [StaffName], [DepartmentsID]) VALUES (2, N'Berit Beritsdottir', 2)
INSERT [dbo].[Staff] ([ID], [StaffName], [DepartmentsID]) VALUES (3, N'Ulf Ulfsson', 3)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkOrders] ON 

INSERT [dbo].[WorkOrders] ([ID], [OrderDescription], [StartingDate], [Commentary], [HoursSpent], [TravelTime], [ExtraCosts], [StaffID], [OrderStatusesID], [CustomersID]) VALUES (1, N'Trasig lampa', CAST(N'2020-09-11' AS Date), N'Allt gick bra', CAST(6 AS Decimal(19, 0)), CAST(4 AS Decimal(19, 0)), CAST(30 AS Decimal(19, 0)), 2, 4, 1)
SET IDENTITY_INSERT [dbo].[WorkOrders] OFF
GO
/****** Object:  Index [UQ__OrderHis__3214EC2618E6DAA4]    Script Date: 2020-09-11 11:38:10 ******/
ALTER TABLE [dbo].[OrderHistory] ADD UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([DepartmentsID])
REFERENCES [dbo].[Departments] ([ID])
GO
ALTER TABLE [dbo].[WorkOrders]  WITH CHECK ADD FOREIGN KEY([CustomersID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[WorkOrders]  WITH CHECK ADD FOREIGN KEY([OrderStatusesID])
REFERENCES [dbo].[OrderStatuses] ([ID])
GO
ALTER TABLE [dbo].[WorkOrders]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([ID])
GO
/****** Object:  Trigger [dbo].[tr_WorkOrders_AfterUpdate]    Script Date: 2020-09-11 11:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_WorkOrders_AfterUpdate]
ON [dbo].[WorkOrders]
AFTER UPDATE
AS
	BEGIN
		DECLARE @OrderStatus INT
		DECLARE @WorkOrderID INT

		SELECT @OrderStatus = OrderStatusesID
		FROM INSERTED

		SELECT @WorkOrderID = ID
		FROM INSERTED

		IF(@OrderStatus = 5)
		BEGIN
		--Lägger över Info från WorkOrders till OrderHistory
			INSERT INTO OrderHistory(ID, OrderDescription, StartingDate, Commentary, HoursSpent, TravelTime, ExtraCosts, StaffID, OrderStatusesID, CustomersID)
			SELECT I.ID, I.OrderDescription, I.StartingDate, I.Commentary, I.HoursSpent, I.TravelTime, I.ExtraCosts, I.StaffID, I.OrderStatusesID, I.CustomersID
			FROM INSERTED I
		--Ta bort från WorkOrders
			DELETE FROM WorkOrders
			WHERE ID = @WorkOrderID
		END
	END
	
GO
ALTER TABLE [dbo].[WorkOrders] ENABLE TRIGGER [tr_WorkOrders_AfterUpdate]
GO
USE [master]
GO
ALTER DATABASE [ToDoApp] SET  READ_WRITE 
GO
