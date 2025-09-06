-- ====================================================
-- Create Database
-- ====================================================
CREATE DATABASE Bank;
GO

ALTER DATABASE [Bank] SET COMPATIBILITY_LEVEL = 160;
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
    EXEC [Bank].[dbo].[sp_fulltext_database] @action = 'enable';
END
GO

-- Basic Database Settings
ALTER DATABASE [Bank] SET ANSI_NULL_DEFAULT OFF;
ALTER DATABASE [Bank] SET ANSI_NULLS OFF;
ALTER DATABASE [Bank] SET ANSI_PADDING OFF;
ALTER DATABASE [Bank] SET ANSI_WARNINGS OFF;
ALTER DATABASE [Bank] SET ARITHABORT OFF;
ALTER DATABASE [Bank] SET AUTO_CLOSE OFF;
ALTER DATABASE [Bank] SET AUTO_SHRINK OFF;
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [Bank] SET CURSOR_CLOSE_ON_COMMIT OFF;
ALTER DATABASE [Bank] SET CURSOR_DEFAULT GLOBAL;
ALTER DATABASE [Bank] SET CONCAT_NULL_YIELDS_NULL OFF;
ALTER DATABASE [Bank] SET NUMERIC_ROUNDABORT OFF;
ALTER DATABASE [Bank] SET QUOTED_IDENTIFIER OFF;
ALTER DATABASE [Bank] SET RECURSIVE_TRIGGERS OFF;
ALTER DATABASE [Bank] SET ENABLE_BROKER;
ALTER DATABASE [Bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF;
ALTER DATABASE [Bank] SET DATE_CORRELATION_OPTIMIZATION OFF;
ALTER DATABASE [Bank] SET TRUSTWORTHY OFF;
ALTER DATABASE [Bank] SET ALLOW_SNAPSHOT_ISOLATION OFF;
ALTER DATABASE [Bank] SET PARAMETERIZATION SIMPLE;
ALTER DATABASE [Bank] SET READ_COMMITTED_SNAPSHOT OFF;
ALTER DATABASE [Bank] SET HONOR_BROKER_PRIORITY OFF;
ALTER DATABASE [Bank] SET RECOVERY FULL;
ALTER DATABASE [Bank] SET MULTI_USER;
ALTER DATABASE [Bank] SET PAGE_VERIFY CHECKSUM;
ALTER DATABASE [Bank] SET DB_CHAINING OFF;
ALTER DATABASE [Bank] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF);
ALTER DATABASE [Bank] SET TARGET_RECOVERY_TIME = 60 SECONDS;
ALTER DATABASE [Bank] SET DELAYED_DURABILITY = DISABLED;
ALTER DATABASE [Bank] SET ACCELERATED_DATABASE_RECOVERY = OFF;
EXEC sys.sp_db_vardecimal_storage_format N'Bank', N'ON';
ALTER DATABASE [Bank] SET QUERY_STORE = ON;
ALTER DATABASE [Bank] SET QUERY_STORE (
    OPERATION_MODE = READ_WRITE, 
    CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), 
    DATA_FLUSH_INTERVAL_SECONDS = 900, 
    INTERVAL_LENGTH_MINUTES = 60, 
    MAX_STORAGE_SIZE_MB = 1000, 
    QUERY_CAPTURE_MODE = AUTO, 
    SIZE_BASED_CLEANUP_MODE = AUTO, 
    MAX_PLANS_PER_QUERY = 200, 
    WAIT_STATS_CAPTURE_MODE = ON
);
GO

USE [Bank];
GO

-- ====================================================
-- Table: Account
-- ====================================================
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
CREATE TABLE [dbo].[Account](
    [AccountNo] INT NOT NULL,
    [FirstName] VARCHAR(30) NULL,
    [LastName] VARCHAR(30) NULL,
    [City] VARCHAR(30) NULL,
    [State] VARCHAR(30) NULL,
    [Amount] NUMERIC(9, 2) NULL,
    [AccountType] VARCHAR(10) NULL,
    [CheqFacil] VARCHAR(10) NULL,
    CONSTRAINT PK_Account PRIMARY KEY CLUSTERED ([AccountNo] ASC)
);
GO

-- ====================================================
-- Table: Trans
-- ====================================================
CREATE TABLE [dbo].[Trans](
    [TranId] INT IDENTITY(1,1) NOT NULL,
    [AccountNo] INT NULL,
    [TranAmount] NUMERIC(9, 2) NULL,
    [TranType] VARCHAR(5) NULL,
    [TranDate] DATE NULL CONSTRAINT DF_Trans_TranDate DEFAULT (GETDATE()),
    CONSTRAINT PK_Trans PRIMARY KEY CLUSTERED ([TranId] ASC),
    CONSTRAINT FK_Trans_Account FOREIGN KEY ([AccountNo]) REFERENCES [dbo].[Account]([AccountNo])
);
GO

-- ====================================================
-- Table: Users
-- ====================================================
CREATE TABLE [dbo].[Users](
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Username] VARCHAR(30) NOT NULL,
    [Passcode] VARCHAR(30) NULL,
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT UQ_Users_Username UNIQUE NONCLUSTERED ([Username] ASC)
);
GO

-- ====================================================
-- Insert Data into Account
-- ====================================================
INSERT [dbo].[Account] ([AccountNo], [FirstName], [LastName], [City], [State], [Amount], [AccountType], [CheqFacil]) VALUES
(1, 'Venkata', 'Gayathri', 'Hyderabad', 'TS', 108222.00, 'Savings', 'Yes'),
(2, 'Raj', 'Kishore', 'Hyd', 'TS', 99222.00, 'Savings', 'Yes'),
(3, 'Ranjan', 'Kishore', 'Hyd', 'TS', 99222.00, 'Savings', 'Yes'),
(4, 'Ram', 'Kishan', 'Hyderabad', 'TS', 90222.00, 'Savings', 'Yes'),
(5, 'Gayathri', 'Venkata', 'Chennai', 'TN', 88222.00, 'Savings', 'Yes'),
(6, 'Abhishek', 'Prabhakar', 'Delhi', 'UP', 99234.00, 'Savings', 'Yes'),
(7, 'Ajay', 'Kumar', 'Chennai', 'TN', 90233.00, 'Savings', 'Yes'),
(8, 'Shri', 'Hari', 'Chennai', 'TN', 90233.00, 'Savings', 'Yes');
GO

-- ====================================================
-- Insert Data into Trans
-- ====================================================
SET IDENTITY_INSERT [dbo].[Trans] ON;
INSERT [dbo].[Trans] ([TranId], [AccountNo], [TranAmount], [TranType], [TranDate]) VALUES
(1, 1, 2000.00, 'C', '2025-03-05'),
(2, 1, 2000.00, 'C', '2025-03-05'),
(3, 1, 2500.00, 'C', '2025-03-05'),
(4, 1, 2500.00, 'D', '2025-03-05'),
(5, 1, 5000.00, 'C', '2025-03-05'),
(6, 1, 10000.00, 'D', '2025-03-05'),
(7, 1, 20000.00, 'C', '2025-03-05'),
(8, 1, 800.00, 'C', '2025-08-02'),
(9, 1, 800.00, 'D', '2025-08-02'),
(10, 7, 10000.00, 'C', '2025-08-02'),
(11, 7, 8000.00, 'D', '2025-08-02'),
(12, 8, 9000.00, 'C', '2025-08-02'),
(13, 8, 7000.00, 'D', '2025-08-02'),
(14, 8, 8000.00, 'C', '2025-08-02'),
(15, 8, 8000.00, 'D', '2025-08-02');
SET IDENTITY_INSERT [dbo].[Trans] OFF;
GO

-- ====================================================
-- Insert Data into Users
-- ====================================================
SET IDENTITY_INSERT [dbo].[Users] ON;
INSERT [dbo].[Users] ([Id], [Username], [Passcode]) VALUES
(1, 'Gayathri', 'Krishna'),
(2, 'Isha', 'Ghosh'),
(3, 'Laksha', 'Katara');
SET IDENTITY_INSERT [dbo].[Users] OFF;
GO

-- Set DB to Read-Write (just to be sure)
USE master;
ALTER DATABASE [Bank] SET READ_WRITE;
GO