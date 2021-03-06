USE [master]
GO
/****** Object:  Database [osteoyoga_test]    Script Date: 10/30/2013 10:56:55 ******/
CREATE DATABASE [osteoyoga_test] ON  PRIMARY 
( NAME = N'osteoyoga_test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLSERVER\MSSQL\DATA\osteoyoga_test.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'osteoyoga_test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLSERVER\MSSQL\DATA\osteoyoga_test_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [osteoyoga_test] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [osteoyoga_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [osteoyoga_test] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [osteoyoga_test] SET ANSI_NULLS OFF
GO
ALTER DATABASE [osteoyoga_test] SET ANSI_PADDING OFF
GO
ALTER DATABASE [osteoyoga_test] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [osteoyoga_test] SET ARITHABORT OFF
GO
ALTER DATABASE [osteoyoga_test] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [osteoyoga_test] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [osteoyoga_test] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [osteoyoga_test] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [osteoyoga_test] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [osteoyoga_test] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [osteoyoga_test] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [osteoyoga_test] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [osteoyoga_test] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [osteoyoga_test] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [osteoyoga_test] SET  DISABLE_BROKER
GO
ALTER DATABASE [osteoyoga_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [osteoyoga_test] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [osteoyoga_test] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [osteoyoga_test] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [osteoyoga_test] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [osteoyoga_test] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [osteoyoga_test] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [osteoyoga_test] SET  READ_WRITE
GO
ALTER DATABASE [osteoyoga_test] SET RECOVERY FULL
GO
ALTER DATABASE [osteoyoga_test] SET  MULTI_USER
GO
ALTER DATABASE [osteoyoga_test] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [osteoyoga_test] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'osteoyoga', N'ON'
GO
USE [osteoyoga_test]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 10/30/2013 10:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] NOT NULL,
	[FullName] [varchar](max) NOT NULL,
	[Phone] [varchar](max) NOT NULL,
	[Mail] [varchar](max) NOT NULL,
	[IsConfirmed] [int] NOT NULL,
	[ConfirmNumber] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 10/30/2013 10:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] NOT NULL,
	[DayOfWeek] [varchar](50) NOT NULL,
	[BeginHour] [time](7) NOT NULL,
	[EndHour] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 10/30/2013 10:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[Id] [int] NOT NULL,
	[Day] [datetime] NOT NULL,
	[BeginHour] [time](7) NOT NULL,
	[EndHour] [time](7) NOT NULL,
 CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Date]    Script Date: 10/30/2013 10:56:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Date](
	[Id] [int] NOT NULL,
	[Day] [datetime] NOT NULL,
	[TimeSlotId] [int] NOT NULL,
	[IsConfirmed] [int] NOT NULL,
	[ConfirmationId] [varchar](max) NOT NULL,
	[ContactId] [int] NOT NULL,
 CONSTRAINT [PK_Date] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Holiday_Holiday]    Script Date: 10/30/2013 10:56:56 ******/
ALTER TABLE [dbo].[Holiday]  WITH CHECK ADD  CONSTRAINT [FK_Holiday_Holiday] FOREIGN KEY([Id])
REFERENCES [dbo].[Holiday] ([Id])
GO
ALTER TABLE [dbo].[Holiday] CHECK CONSTRAINT [FK_Holiday_Holiday]
GO
/****** Object:  ForeignKey [FK_Date_Contact]    Script Date: 10/30/2013 10:56:56 ******/
ALTER TABLE [dbo].[Date]  WITH CHECK ADD  CONSTRAINT [FK_Date_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Date] CHECK CONSTRAINT [FK_Date_Contact]
GO
/****** Object:  ForeignKey [FK_Date_TimeSlot]    Script Date: 10/30/2013 10:56:56 ******/
ALTER TABLE [dbo].[Date]  WITH CHECK ADD  CONSTRAINT [FK_Date_TimeSlot] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlot] ([Id])
GO
ALTER TABLE [dbo].[Date] CHECK CONSTRAINT [FK_Date_TimeSlot]
GO
