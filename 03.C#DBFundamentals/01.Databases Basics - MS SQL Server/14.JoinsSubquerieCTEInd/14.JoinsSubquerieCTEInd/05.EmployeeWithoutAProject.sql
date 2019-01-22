SELECT TOP 3 e.EmployeeID, e.FirstName FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS p
ON e.EmployeeID = p.EmployeeID
WHERE ProjectID IS NULL
ORDER BY e.EmployeeID