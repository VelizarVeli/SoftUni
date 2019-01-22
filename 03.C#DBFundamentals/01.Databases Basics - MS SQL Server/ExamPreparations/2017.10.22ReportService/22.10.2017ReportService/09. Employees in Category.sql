SELECT c.Name AS CategoryName, COUNT(e.DepartmentId) AS [Employees Number] FROM Employees AS e
JOIN Categories AS c ON c.DepartmentId = e.DepartmentId
GROUP BY e.DepartmentId, c.Name
ORDER BY CategoryName, [Employees Number] DESC