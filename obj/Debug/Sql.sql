USE [master]
GO
/****** Object:  Database [eser]    Script Date: 1.06.2022 22:06:29 ******/
CREATE DATABASE [eser]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eser', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eser.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eser_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eser_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [eser] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eser].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eser] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eser] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eser] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eser] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eser] SET ARITHABORT OFF 
GO
ALTER DATABASE [eser] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eser] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eser] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eser] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eser] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eser] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eser] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eser] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eser] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eser] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eser] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eser] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eser] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eser] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eser] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eser] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eser] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eser] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eser] SET  MULTI_USER 
GO
ALTER DATABASE [eser] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eser] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eser] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eser] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eser] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eser] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [eser] SET QUERY_STORE = OFF
GO
USE [eser]
GO
/****** Object:  Table [dbo].[eser_tablo]    Script Date: 1.06.2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eser_tablo](
	[eserID] [int] IDENTITY(1,1) NOT NULL,
	[eser_adi] [nvarchar](50) NOT NULL,
	[eser_sahibi] [nvarchar](50) NULL,
	[eser_kategori] [nvarchar](50) NOT NULL,
	[personel_ad] [nvarchar](50) NOT NULL,
	[giriş_tarihi] [datetime] NULL,
 CONSTRAINT [PK_eser] PRIMARY KEY CLUSTERED 
(
	[eserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[person_login]    Script Date: 1.06.2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[person_login](
	[personID] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [nvarchar](50) NOT NULL,
	[personel_ad] [nvarchar](50) NOT NULL,
	[cinsiyet] [nchar](10) NULL,
	[şifre] [nvarchar](50) NOT NULL,
	[giristarihi] [datetime] NULL,
 CONSTRAINT [PK_person_login] PRIMARY KEY CLUSTERED 
(
	[personID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rezerve_tablo]    Script Date: 1.06.2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rezerve_tablo](
	[ad] [nvarchar](50) NOT NULL,
	[soyad] [nvarchar](50) NOT NULL,
	[giristarihi] [datetime] NOT NULL,
	[girişsaati] [time](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[yonetici_login]    Script Date: 1.06.2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[yonetici_login](
	[username] [nvarchar](50) NOT NULL,
	[sifre] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ziyaret_saatleri]    Script Date: 1.06.2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ziyaret_saatleri](
	[günler] [nvarchar](50) NOT NULL,
	[Tablolar] [nvarchar](50) NOT NULL,
	[Dinieserler] [nvarchar](50) NOT NULL,
	[Tarihieserler] [nvarchar](50) NOT NULL,
	[Heykeller] [nvarchar](50) NOT NULL,
	[Arkeolojikeserler] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ziyaretci_login]    Script Date: 1.06.2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ziyaretci_login](
	[zID] [int] IDENTITY(1,1) NOT NULL,
	[tc] [nvarchar](50) NOT NULL,
	[ad] [nvarchar](50) NOT NULL,
	[soyad] [nvarchar](50) NOT NULL,
	[cinsiyet] [nvarchar](50) NOT NULL,
	[şifre] [nvarchar](50) NOT NULL,
	[giristarihi] [datetime] NULL,
 CONSTRAINT [PK_ziyaretci_login] PRIMARY KEY CLUSTERED 
(
	[zID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[eser_tablo] ON 

INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (1, N'Guernica', N'Pablo Picasso', N'Tablo', N'Ali Ilgaz', CAST(N'2020-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (2, N'Apollo ve Defne', N'Gian Lorenzo Bernini', N'Heykel', N'Selvi Doğru', CAST(N'2010-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (3, N'Mona Lisa', N'Leonardo Da Vİnci', N'Tablo', N'Semih Palan', CAST(N'2022-05-30T20:24:54.770' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (7, N'Arsuz Stelleri', N'Yok', N'Arkeolojik Eser', N'Aybuke Görrmez', CAST(N'2022-06-01T18:13:31.007' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (8, N'Kadem-i Saadet', N'Yok', N'Dini Eserler', N'Semih Palan', CAST(N'2022-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (9, N'Sappho Büstü', N'Yok', N'Tarihi Eserler', N'Selvi Doğru', CAST(N'2022-02-15T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (10, N'İnandık Vazosu', N'Yok', N'Tarihi Eserler', N'Ali Ilgaz', CAST(N'2021-08-25T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (11, N'Çingene Kızı', N'Yok', N'Arkeolojik Eserler', N'Aybuke Görmez', CAST(N'2022-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (12, N'İnci Küpeli Kız', N'Johannes Vermeer', N'Tablo', N'Aybuke Görmez', CAST(N'2019-05-22T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (13, N'Çığlık', N'Edvard Munch', N'Tablo', N'Semih Palan', CAST(N'2021-04-10T00:00:00.000' AS DateTime))
INSERT [dbo].[eser_tablo] ([eserID], [eser_adi], [eser_sahibi], [eser_kategori], [personel_ad], [giriş_tarihi]) VALUES (14, N'Davut', N'Michelangelo Buonarroti', N'Heykel', N'Ali Ilgaz', CAST(N'2020-06-13T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[eser_tablo] OFF
GO
SET IDENTITY_INSERT [dbo].[person_login] ON 

INSERT [dbo].[person_login] ([personID], [tckimlikno], [personel_ad], [cinsiyet], [şifre], [giristarihi]) VALUES (1007, N'41051298264', N'Ali Ilgaz', N'Erkek     ', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T04:22:38.910' AS DateTime))
INSERT [dbo].[person_login] ([personID], [tckimlikno], [personel_ad], [cinsiyet], [şifre], [giristarihi]) VALUES (1008, N'58021268264', N'Selvi Doğru', N'Kadın     ', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T04:23:15.870' AS DateTime))
INSERT [dbo].[person_login] ([personID], [tckimlikno], [personel_ad], [cinsiyet], [şifre], [giristarihi]) VALUES (1009, N'63041268264', N'Semih Palan', N'Erkek     ', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T04:23:44.810' AS DateTime))
INSERT [dbo].[person_login] ([personID], [tckimlikno], [personel_ad], [cinsiyet], [şifre], [giristarihi]) VALUES (1010, N'85961568264', N'Aybuke Görrmez', N'Kadın     ', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T08:54:56.930' AS DateTime))
SET IDENTITY_INSERT [dbo].[person_login] OFF
GO
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Melike', N'Altunköse', CAST(N'2022-05-31T00:00:00.000' AS DateTime), CAST(N'10:00:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Ebru', N'Doğan', CAST(N'2022-06-01T00:00:00.000' AS DateTime), CAST(N'09:00:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Dilek', N'Çakmak', CAST(N'2022-06-01T04:01:48.067' AS DateTime), CAST(N'09:00:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Tülin', N'Budur', CAST(N'2022-06-01T08:39:44.767' AS DateTime), CAST(N'12:30:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Kübra', N'Bitmez', CAST(N'2022-06-01T08:59:16.313' AS DateTime), CAST(N'14:30:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Mustafa', N'Devran', CAST(N'2022-06-01T16:32:17.777' AS DateTime), CAST(N'13:00:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Ebru Hülya', N'Doğan', CAST(N'2022-06-01T20:22:34.473' AS DateTime), CAST(N'09:30:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Ebru hulya', N'dogan', CAST(N'2022-06-01T21:27:19.793' AS DateTime), CAST(N'10:30:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'ebru hülya', N'dogan', CAST(N'2022-06-01T21:32:12.113' AS DateTime), CAST(N'08:30:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Ebru hulya', N'dogan', CAST(N'2022-06-01T21:38:13.597' AS DateTime), CAST(N'09:00:00' AS Time))
INSERT [dbo].[rezerve_tablo] ([ad], [soyad], [giristarihi], [girişsaati]) VALUES (N'Ebru h', N'Doğan', CAST(N'2022-06-01T21:20:26.163' AS DateTime), CAST(N'09:30:00' AS Time))
GO
INSERT [dbo].[yonetici_login] ([username], [sifre]) VALUES (N'admin', N'4ba29b9f9e5732ed33761840f4ba6c53')
GO
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Pazartesi', N'08:00-11:00', N'11:00-14:00', N'12:00-16:00', N'14:00-18:00', N'10:00-15:00')
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Salı', N'12:00-16:00', N'14:00-18:00', N'11:00-14:00', N'10:00-15:00', N'08:00-11:00')
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Çarşamba', N'10:00-15:00', N'08:00-11:00', N'10:00-15:00', N'12:00-16:00', N'11:00-14:00')
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Perşembe', N'14:00-18:00', N'12:00-16:00', N'08:00-11:00', N'10:00-15:00', N'11:00-14:00')
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Cuma', N'08:00-11:00', N'11:00-14:00', N'12:00-16:00', N'14:00-18:00', N'10:00-15:00')
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Cumartesi', N'10:00-15:00', N'10:00-15:00', N'08:00-11:00', N'12:00-16:00', N'11:00-14:00')
INSERT [dbo].[ziyaret_saatleri] ([günler], [Tablolar], [Dinieserler], [Tarihieserler], [Heykeller], [Arkeolojikeserler]) VALUES (N'Pazar', N'-', N'-', N'-', N'-', N'-')
GO
SET IDENTITY_INSERT [dbo].[ziyaretci_login] ON 

INSERT [dbo].[ziyaretci_login] ([zID], [tc], [ad], [soyad], [cinsiyet], [şifre], [giristarihi]) VALUES (34, N'85744569636', N'Kübra', N' Bitmez', N'Kadın', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T08:57:37.353' AS DateTime))
INSERT [dbo].[ziyaretci_login] ([zID], [tc], [ad], [soyad], [cinsiyet], [şifre], [giristarihi]) VALUES (35, N'41041268265', N'Mustafa', N'Devran', N'Erkek', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T16:29:43.470' AS DateTime))
INSERT [dbo].[ziyaretci_login] ([zID], [tc], [ad], [soyad], [cinsiyet], [şifre], [giristarihi]) VALUES (36, N'21427000466', N'Melike', N'Altunköse', N'Kadın', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T18:18:59.873' AS DateTime))
INSERT [dbo].[ziyaretci_login] ([zID], [tc], [ad], [soyad], [cinsiyet], [şifre], [giristarihi]) VALUES (41, N'41051268264', N'Ebru Hülya', N'Doğan', N'Kadın', N'95f656b62f78ccf2873e8b8716442c4d', CAST(N'2022-06-01T21:36:51.263' AS DateTime))
SET IDENTITY_INSERT [dbo].[ziyaretci_login] OFF
GO
USE [master]
GO
ALTER DATABASE [eser] SET  READ_WRITE 
GO
