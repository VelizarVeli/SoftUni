SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], DATENAME(DW,CheckIn) AS [Day of week] FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.EmployeeId IS NULL AND DATEPART(HOUR, CheckOut) - DATEPART(HOUR,  CheckIn) > 12
ORDER BY e.Id