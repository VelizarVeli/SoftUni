SELECT EmployeeId, CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name] FROM Shifts AS s
JOIN Employees AS e ON e.Id = s.EmployeeId
WHERE DATEPART(HOUR, CheckOut) - DATEPART(HOUR,  CheckIn) < 4
GROUP BY s.EmployeeId, CONCAT(e.FirstName, ' ', e.LastName)