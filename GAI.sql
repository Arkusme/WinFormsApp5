--
-- Файл сгенерирован с помощью SQLiteStudio v3.4.4 в Сб ноя 30 18:32:34 2024
--
-- Использованная кодировка текста: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Таблица: Auto
CREATE TABLE IF NOT EXISTS Auto (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CertificateOfRegistration TEXT NOT NULL CHECK(LENGTH(CertificateOfRegistration) = 10),
    Make TEXT NOT NULL,
    Model TEXT NOT NULL,
    LicensePlate TEXT NOT NULL UNIQUE CHECK(LENGTH(LicensePlate) <= 10),
    Year INTEGER NOT NULL,
    OwnerId INTEGER,
    FOREIGN KEY (OwnerId) REFERENCES Drivers(Id)
);

-- Таблица: Drivers
CREATE TABLE IF NOT EXISTS Drivers (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    LastName TEXT NOT NULL CHECK(LENGTH(LastName) <= 15),
    FirstName TEXT NOT NULL CHECK(LENGTH(FirstName) <= 15),
    MiddleName TEXT NOT NULL CHECK(LENGTH(MiddleName) <= 15),
    FullName TEXT NOT NULL CHECK(LENGTH(FullName) <= 20),
    PassportNumber TEXT NOT NULL CHECK(LENGTH(PassportNumber) = 10),
    Phone TEXT NOT NULL CHECK(LENGTH(Phone) = 12),
    Address TEXT NOT NULL CHECK(LENGTH(Address) <= 50),
    CertificateOfRegistration TEXT NOT NULL CHECK(LENGTH(CertificateOfRegistration) = 10),
    DriverLicense TEXT NOT NULL CHECK(LENGTH(DriverLicense) = 10),
    DateOfBirth DATE NOT NULL
);

-- Таблица: Policeman
CREATE TABLE IF NOT EXISTS Policeman (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    LastName TEXT NOT NULL CHECK(LENGTH(LastName) <= 15),
    FirstName TEXT NOT NULL CHECK(LENGTH(FirstName) <= 15),
    MiddleName TEXT NOT NULL CHECK(LENGTH(MiddleName) <= 15),
    FullName TEXT NOT NULL CHECK(LENGTH(FullName) <= 20),
    PassportNumber TEXT NOT NULL CHECK(LENGTH(PassportNumber) = 10),
    Phone TEXT NOT NULL CHECK(LENGTH(Phone) = 12),
    Address TEXT NOT NULL CHECK(LENGTH(Address) <= 50),
    Position TEXT NOT NULL CHECK(LENGTH(Position) <= 15)
);

-- Таблица: Violations
CREATE TABLE IF NOT EXISTS Violations (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    DriverId INTEGER,
    VehicleId INTEGER,
    EmployeeId INTEGER,
    ViolationDate DATE NOT NULL,
    Description TEXT NOT NULL,
    Fine DECIMAL NOT NULL,
    ReferenceInfo TEXT NOT NULL CHECK(LENGTH(ReferenceInfo) <= 1000),
    FOREIGN KEY (DriverId) REFERENCES Drivers(Id),
    FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
