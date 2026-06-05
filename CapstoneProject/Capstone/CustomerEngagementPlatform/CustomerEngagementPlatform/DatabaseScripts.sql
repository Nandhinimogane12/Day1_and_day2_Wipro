-- ==========================================
-- CUSTOMER ENGAGEMENT PLATFORM
-- DATABASE CREATION SCRIPT
-- ==========================================

CREATE DATABASE CustomerEngagementDB;
GO

USE CustomerEngagementDB;
GO

-- ==========================================
-- CUSTOMERS TABLE
-- ==========================================

CREATE TABLE Customers
(
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- ==========================================
-- TICKETS TABLE
-- ==========================================

CREATE TABLE Tickets
(
    TicketId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    Status NVARCHAR(50),
    CustomerId INT,
    CreatedDate DATETIME DEFAULT GETDATE(),

    FOREIGN KEY(CustomerId)
    REFERENCES Customers(CustomerId)
);
GO

-- ==========================================
-- USERS TABLE
-- ==========================================

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100),
    Password NVARCHAR(100),
    Role NVARCHAR(50)
);
GO

-- ==========================================
-- INSERT ADMIN USER
-- ==========================================

INSERT INTO Users
(
    Username,
    Password,
    Role
)
VALUES
(
    'admin',
    'admin123',
    'Admin'
);
GO