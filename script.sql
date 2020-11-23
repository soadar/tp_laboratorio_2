USE [master]
GO
/****** Object:  Database [Cerveceria]    Script Date: 22/11/2020 23:16:30 ******/
CREATE DATABASE [Cerveceria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cerveceria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Cerveceria5.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cerveceria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Cerveceria5_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cerveceria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cerveceria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cerveceria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cerveceria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cerveceria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cerveceria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cerveceria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cerveceria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cerveceria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cerveceria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cerveceria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cerveceria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cerveceria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cerveceria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cerveceria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cerveceria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cerveceria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cerveceria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cerveceria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cerveceria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cerveceria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cerveceria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cerveceria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cerveceria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cerveceria] SET RECOVERY FULL 
GO
ALTER DATABASE [Cerveceria] SET  MULTI_USER 
GO
ALTER DATABASE [Cerveceria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cerveceria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cerveceria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cerveceria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cerveceria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cerveceria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cerveceria', N'ON'
GO
ALTER DATABASE [Cerveceria] SET QUERY_STORE = OFF
GO
USE [Cerveceria]
GO
/****** Object:  Table [dbo].[Cervezas]    Script Date: 22/11/2020 23:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cervezas](
	[Inventario] [int] IDENTITY(1,1) NOT NULL,
	[Estilo] [varchar](50) NOT NULL,
	[Alcohol] [decimal](5, 2) NULL,
	[precio] [decimal](5, 2) NOT NULL,
	[Stock] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cervezas] ON 

INSERT [dbo].[Cervezas] ([Inventario], [Estilo], [Alcohol], [precio], [Stock]) VALUES (1061, N'Porter', CAST(10.00 AS Decimal(5, 2)), CAST(10.00 AS Decimal(5, 2)), 10)
INSERT [dbo].[Cervezas] ([Inventario], [Estilo], [Alcohol], [precio], [Stock]) VALUES (1062, N'Scottish', CAST(20.00 AS Decimal(5, 2)), CAST(20.00 AS Decimal(5, 2)), 20)
INSERT [dbo].[Cervezas] ([Inventario], [Estilo], [Alcohol], [precio], [Stock]) VALUES (1063, N'Manaos', NULL, CAST(30.00 AS Decimal(5, 2)), 30)
INSERT [dbo].[Cervezas] ([Inventario], [Estilo], [Alcohol], [precio], [Stock]) VALUES (1065, N'Pepsi', NULL, CAST(10.50 AS Decimal(5, 2)), 10)
INSERT [dbo].[Cervezas] ([Inventario], [Estilo], [Alcohol], [precio], [Stock]) VALUES (1066, N'Scottish', CAST(8.90 AS Decimal(5, 2)), CAST(300.50 AS Decimal(5, 2)), 90)
INSERT [dbo].[Cervezas] ([Inventario], [Estilo], [Alcohol], [precio], [Stock]) VALUES (1067, N'Porter', CAST(20.00 AS Decimal(5, 2)), CAST(20.00 AS Decimal(5, 2)), 20)
SET IDENTITY_INSERT [dbo].[Cervezas] OFF
GO
USE [master]
GO
ALTER DATABASE [Cerveceria] SET  READ_WRITE 
GO
