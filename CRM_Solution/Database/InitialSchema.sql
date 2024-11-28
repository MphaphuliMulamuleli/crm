-- Create Database
CREATE DATABASE CRM_Test_Dev;
GO

USE CRM_Test_Dev;
GO

-- Create Tables
CREATE TABLE Titles (
    TitleId INT IDENTITY(1,1) PRIMARY KEY,
    TitleName NVARCHAR(50) NOT NULL
);

CREATE TABLE ClientTypes (
    ClientTypeId INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL
);

CREATE TABLE Clients (
    ClientId INT IDENTITY(1,1) PRIMARY KEY,
    TitleId INT FOREIGN KEY REFERENCES Titles(TitleId),
    ClientTypeId INT FOREIGN KEY REFERENCES ClientTypes(ClientTypeId),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    ContactNumber NVARCHAR(20),
    Address NVARCHAR(500),
    ProfilePicture NVARCHAR(MAX),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2
);

CREATE TABLE ClientCredentials (
    CredentialId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    PasswordSalt NVARCHAR(MAX) NOT NULL,
    LastPasswordChange DATETIME2
);

CREATE TABLE Notes (
    NoteId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
    EmployeeId INT NOT NULL, -- Will be linked to Employee table if needed
    Message NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    IsClientVisible BIT DEFAULT 1
);

CREATE TABLE ClientsBackup (
    BackupId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT,
    ClientData NVARCHAR(MAX), -- JSON data of the client
    BackupDate DATETIME2 DEFAULT GETDATE()
);

-- Insert default client types
INSERT INTO ClientTypes (TypeName)
VALUES 
    ('New Client'),
    ('Important Client'),
    ('Super Client'),
    ('Client Removed');

-- Create backup trigger
CREATE TRIGGER TR_Clients_Backup
ON Clients
AFTER DELETE
AS
BEGIN
    INSERT INTO ClientsBackup (ClientId, ClientData)
    SELECT 
        d.ClientId,
        (SELECT * FROM deleted WHERE ClientId = d.ClientId FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM deleted d;
END;