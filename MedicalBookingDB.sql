USE master
GO
-- Tạo cơ sở dữ liệu
CREATE DATABASE MedicalBookingDB
GO
USE MedicalBookingDB
GO
-- 1. Bảng Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    PasswordHash NVARCHAR(255),
    Phone NVARCHAR(20),
    Address NVARCHAR(MAX),
    Role NVARCHAR(20) DEFAULT 'Patient',
    CreatedAt DATETIME DEFAULT GETDATE()
)
GO
-- 2. Bảng Specialties
CREATE TABLE Specialties (
    SpecialtyID INT IDENTITY(1,1) PRIMARY KEY,
    SpecialtyName NVARCHAR(100),
    Description NVARCHAR(MAX)
)
GO
-- 3. Bảng Clinics
CREATE TABLE Clinics (
    ClinicID INT IDENTITY(1,1) PRIMARY KEY,
    ClinicName NVARCHAR(100),
    Address NVARCHAR(MAX),
    Phone NVARCHAR(20),
    Description NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
)
GO
-- 4. Bảng Doctors
CREATE TABLE Doctors (
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    SpecialtyID INT,
    ClinicID INT,
    LicenseNumber NVARCHAR(50),
    ExperienceYears INT,
    Biography NVARCHAR(MAX),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (SpecialtyID) REFERENCES Specialties(SpecialtyID),
    FOREIGN KEY (ClinicID) REFERENCES Clinics(ClinicID)
)
GO
-- 5. Bảng Schedules
CREATE TABLE Schedules (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    DoctorID INT,
    ClinicID INT,
    StartTime DATETIME,
    EndTime DATETIME,
    IsAvailable BIT DEFAULT 1,
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (ClinicID) REFERENCES Clinics(ClinicID)
)
GO
-- 6. Bảng Appointments
CREATE TABLE Appointments (
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    DoctorID INT,
    ScheduleID INT,
    ClinicID INT,
    AppointmentDate DATETIME,
    Status NVARCHAR(50) DEFAULT 'Pending',
    Reason NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (ScheduleID) REFERENCES Schedules(ScheduleID),
    FOREIGN KEY (ClinicID) REFERENCES Clinics(ClinicID)
)
GO
-- 7. Bảng Payments
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentID INT,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
)
GO