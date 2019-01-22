CREATE DATABASE CarRental

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY NOT NULL,
CategoryName VARCHAR (100) NOT NULL,
DailyRate DECIMAL NOT NULL,
WeeklyRate DECIMAL NOT NULL,
MonthlyRate DECIMAL NOT NULL,
WeekendRate DECIMAL NOT NULL
)

INSERT INTO Categories
VALUES 
('Van', 12, 13, 13.4, 13),
('Minivan', 10,9,9.4, 10),
('Hetchback', 14,14,14.4, 14.5)

CREATE TABLE Cars(
Id INT IDENTITY PRIMARY KEY NOT NULL,
PlateNumber VARCHAR(8),
Manufacturer VARCHAR(50),
Model VARCHAR(50),
CarYear DATE,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors REAL,
Picture VARBINARY (MAX),
Condition NVARCHAR(100),
Available BIT
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
('B 0525 A', 'Opel', 'Astra', '1994', 3, 4, 'BRAND NEW WITH RUST', 1),
('A 2241 X', 'Opel', 'Cadet', '1990', 1, 2, 'BRAND NEW WITH RUST', 1),
('X 4452 A', 'Opel', 'Vectra', '1997', 3, 4, 'BRAND NEW WITH RUST', 2)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Title VARCHAR(50),
Notes VARCHAR(MAX)
)

INSERT INTO Employees
VALUES
('Velizar', 'Velikov', 'Title', 'Going to Greece'),
('Antoaneta', 'Hristova', 'Simpatiaga', 'Going to Germany'),
('German', 'Greecov', 'Moving to', 'Going to Albania')

CREATE TABLE Customers(
Id INT IDENTITY PRIMARY KEY NOT NULL,
DriverLicenceNumber BIGINT NOT NULL,
FullName VARCHAR(100), 
Address VARCHAR(MAX), 
City VARCHAR(100),
ZIPCode INT NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Customers
VALUES
(1234567890, 'Arhimanta Gupta', '21 Fascination str', 'Mumbai', 7004, 'Pichaga'),
(0987654321, 'Pipilota Transperanta', '10 Down str', 'Koningsberg', 1234, 'From my childhood'),
(6574839201, 'Viktoria Estin', 'Krasnoselskaia', 'Moscow', 0987, 'Shmatka')

CREATE TABLE RentalOrders (
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel TINYINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays SMALLINT NOT NULL,
	RateApplied NVARCHAR(20) NOT NULL,
	TaxRate DECIMAL(10, 2) NOT NULL,
	OrderStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(1000)
	CONSTRAINT PK_Id_RentalOrders PRIMARY KEY (Id)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus) VALUES
(1, 1, 1, 50, 8450, 8650, 200, '20170512', '20170514', 2, 'WeekendRate', 7.5, 'Finished'),
(2, 2, 2, 60, 10500, 12700, 2200, '20170622', '20170630', 8, 'MonthlyRate', 7.5, 'Finished'),
(3, 3, 3, 65, 2250, 2650, 400, '20170920', '20170924', 4, 'WeeklyRate', 7.5, 'In Progress')
SELECT * FROM RentalOrders