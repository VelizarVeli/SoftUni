CREATE TABLE Manufacturers
(
ManufacturerID INT IDENTITY PRIMARY KEY,
Name NVARCHAR(100),
EstablishedOn DATE,
)

CREATE TABLE Models
(
ModelID INT PRIMARY KEY,
Name NVARCHAR(100),
ManufacturerID INT,
)


ALTER TABLE Models 
ADD CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers (ManufacturerID)

INSERT Manufacturers
(Name, EstablishedOn)
VALUES
('BMW', '1916/03/07'),
('Tesla', '2003/01/01'),
('Lada', '1966/05/01')

INSERT Models
(ModelID, Name, ManufacturerID)
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)