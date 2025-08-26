USE [master]
GO
/****** Object:  Database [cms]    Script Date: 16-08-2025 11:15:13 ******/
DROP DATABASE [CarRental]
GO

CREATE DATABASE [CarRental]
GO
USE [CarRental];

CREATE TABLE [dbo].[Vehicle](
	[vehicleId] [int] PRIMARY KEY IDENTITY,
	[make] [varchar](30) NULL,
	[model] [varchar](30) NULL,
	[year] [varchar](30) NULL,
	[dailyRate] [varchar](30) NULL,
	[status] [varchar](30) NULL,
	[passengerCapacity] [varchar](30) NULL,
	[engineCapacity] [varchar](20) NULL,
);

CREATE TABLE [dbo].[Customer](
	[customerId] [int] PRIMARY KEY IDENTITY,
	[firstName] [varchar](30) NULL,
	[lastName] [varchar](30) NULL,
	[email] [varchar](30) NULL,
	[phoneNumber] [varchar](30) NULL,
);


CREATE TABLE [dbo].[User](
	[Id] int PRIMARY KEY IDENTITY,
	[userName] [varchar](30) NULL,
	[password] [varchar](30) NULL,
);


INSERT INTO [dbo].[User] (Id, userName, password) 
VALUES(1,'Charan', 'Charan123');