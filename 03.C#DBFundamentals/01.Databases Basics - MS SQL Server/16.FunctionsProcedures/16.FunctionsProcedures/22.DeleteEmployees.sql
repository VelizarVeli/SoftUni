CREATE TABLE Deleted_Employees
(
             EmployeeId   INT IDENTITY,
             FirstName    NVARCHAR(50),
             LastName     NVARCHAR(50),
             MiddleName   NVARCHAR(50),
             JobTitle     NVARCHAR(50),
             DepartmentId INT,
             Salary       DECIMAL(15, 2),
             CONSTRAINT PK_Deleted_Employees PRIMARY KEY(EmployeeId),
             CONSTRAINT FK_Deleted_Employees_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId)
);
GO

/* Only trigger creation for JUDGE */
CREATE TRIGGER tr_DeletedEmployeesSaver ON Employees
AFTER DELETE
AS
     BEGIN
         INSERT INTO Deleted_Employees
                SELECT FirstName,
                       LastName,
                       MiddleName,
                       JobTitle,
                       DepartmentID,
                       Salary
                FROM deleted;
     END;