-- ===========================
-- Create Database
-- ===========================
CREATE DATABASE HotelBookingReservation;
GO

USE HotelBookingReservation;
GO

-- ===========================
-- Users Table
-- ===========================
CREATE TABLE [dbo].[Users](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL,
    [CreatedAt] DATETIME NULL DEFAULT GETDATE()
);

-- ===========================
-- Hotels Table
-- ===========================
CREATE TABLE [dbo].[Hotels](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(255) NULL,
    [City] NVARCHAR(50) NULL,
    [Country] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NULL DEFAULT GETDATE()
);

-- ===========================
-- Rooms Table
-- ===========================
CREATE TABLE [dbo].[Rooms](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [HotelId] INT NOT NULL,
    [RoomNumber] NVARCHAR(20) NOT NULL,
    [Type] NVARCHAR(50) NOT NULL,
    [Price] DECIMAL(10, 2) NOT NULL,
    [IsAvailable] BIT NULL DEFAULT 1,
    FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotels]([Id]) ON DELETE CASCADE
);

-- ===========================
-- Bookings Table
-- ===========================
CREATE TABLE [dbo].[Bookings](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [UserId] INT NOT NULL,
    [RoomId] INT NOT NULL,
    [CheckInDate] DATE NOT NULL,
    [CheckOutDate] DATE NOT NULL,
    [TotalPrice] DECIMAL(10, 2) NOT NULL,
    [Status] NVARCHAR(20) NULL DEFAULT 'Pending',
    [CreatedAt] DATETIME NULL DEFAULT GETDATE(),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms]([Id]) ON DELETE CASCADE
);

-- ===========================
-- Payments Table
-- ===========================
CREATE TABLE [dbo].[Payments](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [BookingId] INT NOT NULL,
    [PaymentDate] DATETIME NULL DEFAULT GETDATE(),
    [Amount] DECIMAL(10, 2) NOT NULL,
    [PaymentMethod] NVARCHAR(50) NULL,
    [Status] NVARCHAR(20) NULL DEFAULT 'Pending',
    FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Bookings]([Id]) ON DELETE CASCADE
);

-- ===========================
-- Seed Admin User
-- ===========================
INSERT INTO [dbo].[Users] ([Name], [Email], [PasswordHash], [Role])
VALUES ('vasim', 'vasim@gmail.com',
        '$2a$11$9Ez8MbQnV52bdKciQQOG3OKozv.FBCtOTyB1WUoQ9nmjhnLp5pB1e',
        'Admin');

-- password = reddy


-- ===========================
-- Seed Hotels
-- ===========================
INSERT INTO [dbo].[Hotels] ([Name], [Address], [City], [Country])
VALUES 
('Taj Palace', '1 Taj Road', 'Mumbai', 'India'),
('Og Grand', '15 Jawaharlal Nehru Road', 'Kolkata', 'India'),
('ITC Maurya', 'Diplomatic Enclave', 'New Delhi', 'India'),
('Leela Palace', 'Old Airport Road', 'Bengaluru', 'India'),
('royal Blu', 'Near Airport', 'Hyderabad', 'India');

-- ===========================
-- Seed Rooms
-- ===========================

-- Hotel 1: Taj Palace
INSERT INTO [dbo].[Rooms] ([HotelId], [RoomNumber], [Type], [Price], [IsAvailable]) VALUES
(1, '101', 'Standard', 6000.00, 1),
(1, '102', 'Deluxe', 10000.00, 1),
(1, '103', 'Royal Suite', 18000.00, 1);

-- Hotel 2: Og Grand
INSERT INTO [dbo].[Rooms] ([HotelId], [RoomNumber], [Type], [Price], [IsAvailable]) VALUES
(2, '201', 'Standard', 5500.00, 1),
(2, '202', 'Deluxe', 9500.00, 1),
(2, '203', 'Royal Suite', 17000.00, 1);

-- Hotel 3: ITC Maurya
INSERT INTO [dbo].[Rooms] ([HotelId], [RoomNumber], [Type], [Price], [IsAvailable]) VALUES
(3, '301', 'Standard', 5800.00, 1),
(3, '302', 'Deluxe', 9700.00, 1),
(3, '303', 'Royal Suite', 17500.00, 1);

-- Hotel 4: Leela Palace
INSERT INTO [dbo].[Rooms] ([HotelId], [RoomNumber], [Type], [Price], [IsAvailable]) VALUES
(4, '401', 'Standard', 6200.00, 1),
(4, '402', 'Deluxe', 10200.00, 1),
(4, '403', 'Royal Suite', 18500.00, 1);

-- Hotel 5: Royal Blu
INSERT INTO [dbo].[Rooms] ([HotelId], [RoomNumber], [Type], [Price], [IsAvailable]) VALUES
(5, '501', 'Standard', 5700.00, 1),
(5, '502', 'Deluxe', 9300.00, 1),
(5, '503', 'Royal Suite', 16500.00, 1);






