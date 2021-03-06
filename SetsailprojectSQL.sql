USE [master]
GO
/****** Object:  Database [SetSailTravel]    Script Date: 11/22/2020 4:29:58 PM ******/
CREATE DATABASE [SetSailTravel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SetSailTravel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SetSailTravel.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SetSailTravel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SetSailTravel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SetSailTravel] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SetSailTravel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SetSailTravel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SetSailTravel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SetSailTravel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SetSailTravel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SetSailTravel] SET ARITHABORT OFF 
GO
ALTER DATABASE [SetSailTravel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SetSailTravel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SetSailTravel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SetSailTravel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SetSailTravel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SetSailTravel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SetSailTravel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SetSailTravel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SetSailTravel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SetSailTravel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SetSailTravel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SetSailTravel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SetSailTravel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SetSailTravel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SetSailTravel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SetSailTravel] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SetSailTravel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SetSailTravel] SET RECOVERY FULL 
GO
ALTER DATABASE [SetSailTravel] SET  MULTI_USER 
GO
ALTER DATABASE [SetSailTravel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SetSailTravel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SetSailTravel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SetSailTravel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SetSailTravel] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SetSailTravel', N'ON'
GO
ALTER DATABASE [SetSailTravel] SET QUERY_STORE = OFF
GO
USE [SetSailTravel]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Abouts]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopText] [nvarchar](200) NOT NULL,
	[Text] [ntext] NOT NULL,
	[BgImage] [nvarchar](250) NULL,
	[Image] [nvarchar](250) NULL,
	[PopImage] [nvarchar](250) NULL,
	[VideoImage] [nvarchar](250) NULL,
	[Video] [nvarchar](250) NULL,
	[MPImage] [nvarchar](250) NULL,
	[BlogsBgImage] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Abouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Photo] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogCategories]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.BlogCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogComments]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[BlogId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BlogComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[BgImage] [nvarchar](250) NULL,
	[MainImage] [nvarchar](250) NULL,
	[TopText] [nvarchar](200) NOT NULL,
	[Text1] [ntext] NOT NULL,
	[Quote] [nvarchar](250) NOT NULL,
	[Text2] [ntext] NOT NULL,
	[Image1] [nvarchar](250) NULL,
	[Image2] [nvarchar](250) NULL,
	[Text3] [ntext] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[BlogCategoryId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Tickets] [tinyint] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[TourId] [int] NOT NULL,
	[UserId] [int] NULL,
	[DateId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CityPages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopTitle1] [nvarchar](30) NOT NULL,
	[Title1] [nvarchar](30) NOT NULL,
	[introText1] [nvarchar](150) NOT NULL,
	[TopTitle2] [nvarchar](30) NOT NULL,
	[Title2] [nvarchar](30) NOT NULL,
	[introText2] [nvarchar](150) NOT NULL,
	[TopTitle3] [nvarchar](30) NOT NULL,
	[Title3] [nvarchar](30) NOT NULL,
	[introText3] [nvarchar](150) NOT NULL,
	[IntroImage1] [nvarchar](250) NULL,
	[IntroImage2] [nvarchar](250) NULL,
	[IntroImage3] [nvarchar](250) NULL,
	[Video] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.CityPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactCities]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactCities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ContactCountryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ContactCities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactCountries]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactCountries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.ContactCountries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactReplies]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactReplies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ContactReplies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone1] [nvarchar](50) NOT NULL,
	[Phone2] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Map] [nvarchar](500) NOT NULL,
	[ContactCityId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactSocials]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactSocials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](30) NOT NULL,
	[Link] [nvarchar](250) NOT NULL,
	[ContactId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ContactSocials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DayIncludes]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DayIncludes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Feature] [nvarchar](30) NOT NULL,
	[DayId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DayIncludes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Days]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[Consist] [nvarchar](300) NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Days] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destinations]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Text1] [ntext] NOT NULL,
	[Pic1] [nvarchar](250) NULL,
	[Pic2] [nvarchar](250) NULL,
	[Text2] [ntext] NOT NULL,
	[Visa] [nvarchar](50) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
	[MunText] [ntext] NOT NULL,
	[Pic3] [nvarchar](250) NULL,
	[Pic4] [nvarchar](250) NULL,
	[Pic5] [nvarchar](250) NULL,
	[Pic6] [nvarchar](250) NULL,
	[Video] [nvarchar](250) NOT NULL,
	[BgImage] [nvarchar](250) NULL,
	[SliderImage] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Destinations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExoticPages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExoticPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopTitle1] [nvarchar](30) NOT NULL,
	[Title1] [nvarchar](30) NOT NULL,
	[introText1] [nvarchar](150) NOT NULL,
	[TopTitle2] [nvarchar](30) NOT NULL,
	[Title2] [nvarchar](30) NOT NULL,
	[introText2] [nvarchar](150) NOT NULL,
	[IntroImage1] [nvarchar](250) NULL,
	[IntroImage2] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.ExoticPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faqs]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faqs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](50) NOT NULL,
	[Answer] [ntext] NOT NULL,
	[BgImage] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Faqs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomePages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopTitle1] [nvarchar](30) NOT NULL,
	[Title1] [nvarchar](30) NOT NULL,
	[introText2] [nvarchar](150) NOT NULL,
	[TopTitle2] [nvarchar](30) NOT NULL,
	[Title2] [nvarchar](30) NOT NULL,
	[introText1] [nvarchar](150) NOT NULL,
	[IntroImage1] [nvarchar](250) NULL,
	[IntroImage2] [nvarchar](250) NULL,
	[VideoImage] [nvarchar](250) NULL,
	[ParallaxImage1] [nvarchar](250) NULL,
	[ParallaxImage2] [nvarchar](250) NULL,
	[BestTourName] [nvarchar](30) NOT NULL,
	[Destination1] [nvarchar](30) NOT NULL,
	[Destination2] [nvarchar](30) NOT NULL,
	[Destination3] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.HomePages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Includes]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Includes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Feature] [nvarchar](30) NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Includes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotIncludes]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotIncludes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Feature] [nvarchar](30) NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.NotIncludes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReviews]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[Rating] [tinyint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ProductReviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[About] [nvarchar](250) NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [tinyint] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[AdminId] [int] NOT NULL,
	[Width] [money] NOT NULL,
	[Height] [money] NOT NULL,
	[Length] [money] NOT NULL,
	[Weight] [money] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Subscriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SummerPages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SummerPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopTitle1] [nvarchar](30) NOT NULL,
	[Title1] [nvarchar](30) NOT NULL,
	[introText1] [nvarchar](150) NOT NULL,
	[TopTitle2] [nvarchar](30) NOT NULL,
	[Title2] [nvarchar](30) NOT NULL,
	[introText2] [nvarchar](150) NOT NULL,
	[TopTitle3] [nvarchar](30) NOT NULL,
	[Title3] [nvarchar](30) NOT NULL,
	[introText3] [nvarchar](150) NOT NULL,
	[TopTitle4] [nvarchar](30) NOT NULL,
	[Title4] [nvarchar](30) NOT NULL,
	[introText4] [nvarchar](150) NOT NULL,
	[IntroImage1] [nvarchar](250) NULL,
	[IntroImage2] [nvarchar](250) NULL,
	[IntroImage3] [nvarchar](250) NULL,
	[IntroImage4] [nvarchar](250) NULL,
	[VideoImage] [nvarchar](250) NULL,
	[ParallaxImage1] [nvarchar](250) NULL,
	[ParallaxImage2] [nvarchar](250) NULL,
	[Video] [nvarchar](250) NOT NULL,
	[BestTourName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.SummerPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](30) NOT NULL,
	[About] [nvarchar](100) NOT NULL,
	[Photo] [nvarchar](250) NULL,
	[PositionId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamSocials]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamSocials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](30) NOT NULL,
	[Link] [nvarchar](250) NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TeamSocials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourCategories]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.TourCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourCities]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourCities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[History] [ntext] NOT NULL,
	[Map] [nvarchar](500) NOT NULL,
	[DestinationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TourCities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourDates]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourDates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[TourId] [int] NOT NULL,
	[TicketsNum] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo.TourDates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourImages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](250) NOT NULL,
	[TourId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TourImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourReviews]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourReviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[Rating] [tinyint] NOT NULL,
	[Comfort] [tinyint] NOT NULL,
	[Food] [tinyint] NOT NULL,
	[Hospitality] [tinyint] NOT NULL,
	[Hygiene] [tinyint] NOT NULL,
	[Reception] [tinyint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[TourId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TourReviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tours]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[BgImage] [nvarchar](250) NULL,
	[Price] [money] NOT NULL,
	[About] [ntext] NOT NULL,
	[Age] [tinyint] NOT NULL,
	[DeparturePlace] [nvarchar](50) NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[ReturnTime] [time](7) NOT NULL,
	[DressCode] [nvarchar](30) NOT NULL,
	[Text] [ntext] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[AdminId] [int] NOT NULL,
	[TourCityId] [int] NOT NULL,
	[FrontImage] [nvarchar](250) NULL,
	[TourCategoryId] [int] NOT NULL,
	[TourTypeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourTypes]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.TourTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Photo] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WinePages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WinePages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[introTitleImage1] [nvarchar](250) NULL,
	[introTitleImage2] [nvarchar](250) NULL,
	[introTitleImage3] [nvarchar](250) NULL,
	[IntroImage1] [nvarchar](250) NULL,
	[IntroImage1s] [nvarchar](250) NULL,
	[IntroImage2] [nvarchar](250) NULL,
	[IntroImage2s] [nvarchar](250) NULL,
	[IntroImage3] [nvarchar](250) NULL,
	[IntroImage3s] [nvarchar](250) NULL,
	[VideoImage] [nvarchar](250) NULL,
	[PopImage1] [nvarchar](250) NULL,
	[PopImage2] [nvarchar](250) NULL,
	[Glasses] [int] NOT NULL,
	[Years] [int] NOT NULL,
	[Uniques] [int] NOT NULL,
	[Sorts] [int] NOT NULL,
	[PopSlogan] [nvarchar](150) NOT NULL,
	[PopText1] [nvarchar](100) NOT NULL,
	[PopText2] [nvarchar](100) NOT NULL,
	[PopText3] [nvarchar](100) NOT NULL,
	[PopText4] [nvarchar](100) NOT NULL,
	[Video] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.WinePages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WinterPages]    Script Date: 11/22/2020 4:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WinterPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopTitle1] [nvarchar](30) NOT NULL,
	[Title1] [nvarchar](30) NOT NULL,
	[introText1] [nvarchar](150) NOT NULL,
	[TopTitle2] [nvarchar](30) NOT NULL,
	[Title2] [nvarchar](30) NOT NULL,
	[introText2] [nvarchar](150) NOT NULL,
	[IntroImage1] [nvarchar](250) NULL,
	[IntroImage2] [nvarchar](250) NULL,
	[VideoImage] [nvarchar](max) NULL,
	[ParallaxImage1] [nvarchar](250) NULL,
	[Video] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.WinterPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogId] ON [dbo].[BlogComments]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[BlogComments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogCategoryId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogCategoryId] ON [dbo].[Blogs]
(
	[BlogCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Blogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[Bookings]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Bookings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactCountryId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContactCountryId] ON [dbo].[ContactCities]
(
	[ContactCountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[ContactReplies]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactCityId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContactCityId] ON [dbo].[Contacts]
(
	[ContactCityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContactId] ON [dbo].[ContactSocials]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DayId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_DayId] ON [dbo].[DayIncludes]
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[Days]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[Includes]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[NotIncludes]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ProductImages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ProductReviews]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[ProductReviews]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AdminId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_AdminId] ON [dbo].[Products]
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategoryId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategoryId] ON [dbo].[Products]
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_PositionId] ON [dbo].[Teams]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeamId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeamId] ON [dbo].[TeamSocials]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DestinationId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_DestinationId] ON [dbo].[TourCities]
(
	[DestinationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[TourDates]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[TourImages]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourId] ON [dbo].[TourReviews]
(
	[TourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[TourReviews]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AdminId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_AdminId] ON [dbo].[Tours]
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourCategoryId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourCategoryId] ON [dbo].[Tours]
(
	[TourCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourCityId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourCityId] ON [dbo].[Tours]
(
	[TourCityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TourTypeId]    Script Date: 11/22/2020 4:29:59 PM ******/
CREATE NONCLUSTERED INDEX [IX_TourTypeId] ON [dbo].[Tours]
(
	[TourTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings] ADD  DEFAULT ((0)) FOR [DateId]
GO
ALTER TABLE [dbo].[HomePages] ADD  DEFAULT ('') FOR [BestTourName]
GO
ALTER TABLE [dbo].[HomePages] ADD  DEFAULT ('') FOR [Destination1]
GO
ALTER TABLE [dbo].[HomePages] ADD  DEFAULT ('') FOR [Destination2]
GO
ALTER TABLE [dbo].[HomePages] ADD  DEFAULT ('') FOR [Destination3]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('') FOR [About]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [AdminId]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Width]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Height]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Length]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[SummerPages] ADD  DEFAULT ('') FOR [BestTourName]
GO
ALTER TABLE [dbo].[TourDates] ADD  DEFAULT ((0)) FOR [TicketsNum]
GO
ALTER TABLE [dbo].[BlogComments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogComments_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogComments] CHECK CONSTRAINT [FK_dbo.BlogComments_dbo.Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogComments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogComments_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogComments] CHECK CONSTRAINT [FK_dbo.BlogComments_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Blogs_dbo.BlogCategories_BlogCategoryId] FOREIGN KEY([BlogCategoryId])
REFERENCES [dbo].[BlogCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_dbo.Blogs_dbo.BlogCategories_BlogCategoryId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Blogs_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_dbo.Blogs_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Bookings_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo.Bookings_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Bookings_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo.Bookings_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[ContactCities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContactCities_dbo.ContactCountries_ContactCountryId] FOREIGN KEY([ContactCountryId])
REFERENCES [dbo].[ContactCountries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactCities] CHECK CONSTRAINT [FK_dbo.ContactCities_dbo.ContactCountries_ContactCountryId]
GO
ALTER TABLE [dbo].[ContactReplies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContactReplies_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactReplies] CHECK CONSTRAINT [FK_dbo.ContactReplies_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contacts_dbo.ContactCities_ContactCityId] FOREIGN KEY([ContactCityId])
REFERENCES [dbo].[ContactCities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_dbo.Contacts_dbo.ContactCities_ContactCityId]
GO
ALTER TABLE [dbo].[ContactSocials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContactSocials_dbo.Contacts_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactSocials] CHECK CONSTRAINT [FK_dbo.ContactSocials_dbo.Contacts_ContactId]
GO
ALTER TABLE [dbo].[DayIncludes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DayIncludes_dbo.Days_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[Days] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DayIncludes] CHECK CONSTRAINT [FK_dbo.DayIncludes_dbo.Days_DayId]
GO
ALTER TABLE [dbo].[Days]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Days_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Days] CHECK CONSTRAINT [FK_dbo.Days_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[Includes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Includes_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Includes] CHECK CONSTRAINT [FK_dbo.Includes_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[NotIncludes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.NotIncludes_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NotIncludes] CHECK CONSTRAINT [FK_dbo.NotIncludes_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductImages_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_dbo.ProductImages_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductReviews_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK_dbo.ProductReviews_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[ProductReviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductReviews_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductReviews] CHECK CONSTRAINT [FK_dbo.ProductReviews_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Admins_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Admins_AdminId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.ProductCategories_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.ProductCategories_ProductCategoryId]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teams_dbo.Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_dbo.Teams_dbo.Positions_PositionId]
GO
ALTER TABLE [dbo].[TeamSocials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeamSocials_dbo.Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamSocials] CHECK CONSTRAINT [FK_dbo.TeamSocials_dbo.Teams_TeamId]
GO
ALTER TABLE [dbo].[TourCities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TourCities_dbo.Destinations_DestinationId] FOREIGN KEY([DestinationId])
REFERENCES [dbo].[Destinations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourCities] CHECK CONSTRAINT [FK_dbo.TourCities_dbo.Destinations_DestinationId]
GO
ALTER TABLE [dbo].[TourDates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TourDates_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourDates] CHECK CONSTRAINT [FK_dbo.TourDates_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[TourImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TourImages_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourImages] CHECK CONSTRAINT [FK_dbo.TourImages_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[TourReviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TourReviews_dbo.Tours_TourId] FOREIGN KEY([TourId])
REFERENCES [dbo].[Tours] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourReviews] CHECK CONSTRAINT [FK_dbo.TourReviews_dbo.Tours_TourId]
GO
ALTER TABLE [dbo].[TourReviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TourReviews_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TourReviews] CHECK CONSTRAINT [FK_dbo.TourReviews_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tours_dbo.Admins_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_dbo.Tours_dbo.Admins_AdminId]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tours_dbo.TourCategories_TourCategoryId] FOREIGN KEY([TourCategoryId])
REFERENCES [dbo].[TourCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_dbo.Tours_dbo.TourCategories_TourCategoryId]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tours_dbo.TourCities_TourCityId] FOREIGN KEY([TourCityId])
REFERENCES [dbo].[TourCities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_dbo.Tours_dbo.TourCities_TourCityId]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tours_dbo.TourTypes_TourTypeId] FOREIGN KEY([TourTypeId])
REFERENCES [dbo].[TourTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_dbo.Tours_dbo.TourTypes_TourTypeId]
GO
USE [master]
GO
ALTER DATABASE [SetSailTravel] SET  READ_WRITE 
GO
