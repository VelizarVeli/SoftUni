SELECT TOP 10 FirstName, LastName, DepartmentID FROM Employees AS e
WHERE Salary > (
	SELECT AVG(Salary) FROM Employees AS e2
	WHERE e2.DepartmentID = e.DepartmentID
	)
ORDER BY DepartmentID