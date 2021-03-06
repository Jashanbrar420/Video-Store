USE [master]
GO
/****** Object:  Database [VSR_System]    Script Date: 5/16/2019 6:20:49 AM ******/
CREATE DATABASE [VSR_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VSR_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VSR_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VSR_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VSR_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VSR_System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VSR_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VSR_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VSR_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VSR_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VSR_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VSR_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [VSR_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VSR_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VSR_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VSR_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VSR_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VSR_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VSR_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VSR_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VSR_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VSR_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VSR_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VSR_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VSR_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VSR_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VSR_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VSR_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VSR_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VSR_System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VSR_System] SET  MULTI_USER 
GO
ALTER DATABASE [VSR_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VSR_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VSR_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VSR_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VSR_System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'VSR_System', N'ON'
GO
ALTER DATABASE [VSR_System] SET QUERY_STORE = OFF
GO
USE [VSR_System]
GO
/****** Object:  Table [dbo].[Coustmer]    Script Date: 5/16/2019 6:20:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coustmer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 5/16/2019 6:20:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Year] [nvarchar](50) NULL,
	[Rental_Cost] [money] NULL,
	[Plot] [ntext] NULL,
	[Genre] [nchar](10) NULL,
	[copies] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 5/16/2019 6:20:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NULL,
	[CustIDFK] [int] NULL,
	[DateRented] [datetime] NULL,
	[DateReturned] [datetime] NULL,
 CONSTRAINT [PK_RentedMovie] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coustmer] ON 

INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (3, N'jack', N'tod', N'South Road', N'02283823')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (4, N'sam', N'vick', N'greenwood road', N'02993843')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (5, N'kevin', N'smith', N'garrison road', N'0291831921')
SET IDENTITY_INSERT [dbo].[Coustmer] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (3, N'5', N'big bang thoery', N'2015', 5.0000, N'sci', N'sci       ', 20)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (4, N'5', N'john vick', N'2018', 5.0000, N'sci', N'sci       ', 12)
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (1, 2, 2, CAST(N'2019-05-16T05:44:51.893' AS DateTime), CAST(N'2019-05-16T05:44:55.000' AS DateTime))
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (2, 2, 2, CAST(N'2019-05-16T05:52:44.197' AS DateTime), CAST(N'2019-05-16T06:07:33.000' AS DateTime))
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned]) VALUES (3, 3, 5, CAST(N'2019-05-16T06:12:39.773' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
USE [master]
GO
ALTER DATABASE [VSR_System] SET  READ_WRITE 
GO
