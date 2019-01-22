SELECT * FROM Employees
WHERE EmployeeID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = 1)


SELECT * FROM Employees 
WHERE DepartmentID = 1