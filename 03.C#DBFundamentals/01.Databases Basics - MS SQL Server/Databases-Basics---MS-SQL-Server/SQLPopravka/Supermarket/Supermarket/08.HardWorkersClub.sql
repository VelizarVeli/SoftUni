SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR,s.CheckIn, CheckOut)) AS [Work hours] FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id
HAVING AVG(DATEPART(HOUR,s.CheckOut) - DATEPART(HOUR, s.CheckIn)) > 7
ORDER BY AVG(DATEDIFF(HOUR,s.CheckIn, CheckOut)) DESC, e.Id
