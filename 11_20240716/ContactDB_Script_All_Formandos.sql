-- Create database
USE [master]
GO


-- Configuration
SET NOCOUNT ON;


-- Change the name and path
CREATE DATABASE [ContactDB_EFCore_DatabaseFirst]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactDB', FILENAME = N'C:\Cegid\ContactDB_EFCore_DatabaseFirst.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactDB_log', FILENAME = N'C:C:\Cegid\ContactDB_EFCore_DatabaseFirst_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO


-- Use database
USE [ContactDB_EFCore_Database1st]
GO


-- Create table Contact
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](12) NULL,
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


-- Create table Address
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[ContactID] [int] NOT NULL,
	[ContactAddress] [nvarchar](150) NOT NULL,
	[ZipCode] [nvarchar](8) NOT NULL,
	[City] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


-- Insert Contact data
INSERT [dbo].[Contact] ([ContactName], [Email], [Phone]) VALUES (N'Person A', N'a@mail.com', '912345678')
GO
INSERT [dbo].[Contact] ([ContactName], [Email], [Phone]) VALUES (N'Person B', N'b@mail.com', '932345678')
GO
INSERT [dbo].[Contact] ([ContactName], [Email], [Phone]) VALUES (N'Person C', N'c@mail.com', '962345678')
GO



-- Insert Address data
INSERT [dbo].[Address] ([ContactID], [ContactAddress], [ZipCode], [City]) VALUES (1, N'R. 19, 345', N'4500-100', N'Espinho')
GO
INSERT [dbo].[Address] ([ContactID], [ContactAddress], [ZipCode], [City]) VALUES (2, N'Al. Espinhosa, 98', N'4414-543', N'Gaia')
GO
INSERT [dbo].[Address] ([ContactID], [ContactAddress], [ZipCode], [City]) VALUES (1, N'Av. Norte, 123, 1 dto.', N'4100-213', N'Porto')
GO


-- Define relationship between Contact (1) and Address (n)
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Address_dbo.Contact_ContactID] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ContactID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_dbo.Address_dbo.Contact_ContactID]
GO


-- Configuration
SET NOCOUNT OFF;