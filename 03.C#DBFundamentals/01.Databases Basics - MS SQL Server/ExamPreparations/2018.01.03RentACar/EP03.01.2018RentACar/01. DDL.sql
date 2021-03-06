CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName  NVARCHAR(30) NOT NULL,
Gender CHAR(1) CHECK (Gender IN ('M', 'F')),
BirthDate DATETIME,
CreditCard NVARCHAR(30) NOT NULL,
CardValidity DATETIME,
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Offices(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(40),
ParkingPlaces INT,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Models(
Id INT PRIMARY KEY IDENTITY,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(50) NOT NULL,
ProductionYear DATETIME,
Seats INT,
Class NVARCHAR(10),
Consumption DECIMAL(14, 2)
)

CREATE TABLE Vehicles(
Id INT PRIMARY KEY IDENTITY,
ModelId INT FOREIGN KEY REFERENCES Models(Id) NOT NULL,
OfficeId INT FOREIGN KEY REFERENCES Offices(Id) NOT NULL,
Mileage INT
)

CREATE TABLE Orders(
Id INT PRIMARY KEY IDENTITY,
ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
VehicleId INT FOREIGN KEY REFERENCES Vehicles(Id) NOT NULL,
CollectionDate DATETIME NOT NULL,
CollectionOfficeId INT FOREIGN KEY REFERENCES Offices(Id) NOT NULL, --Relationship with table Offices
ReturnDate DATETIME, --FOREIGN KEY REFERENCES Offices(Id), --Relationship with table Offices
ReturnOfficeId INT FOREIGN KEY REFERENCES Offices(Id), --Relationship with table Offices
Bill DECIMAL (14, 2),
TotalMileage INT
)