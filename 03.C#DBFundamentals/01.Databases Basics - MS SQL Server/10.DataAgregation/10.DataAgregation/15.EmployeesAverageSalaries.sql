SELECT * 
INTO EmployeesWithHighSalary
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalary
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM EmployeesWithHighSalary
GROUP BY DepartmentID