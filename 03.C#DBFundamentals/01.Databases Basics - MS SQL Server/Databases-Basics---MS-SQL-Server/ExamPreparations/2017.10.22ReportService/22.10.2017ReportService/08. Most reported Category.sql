SELECT c.Name AS CategoryName, COUNT(r.CategoryId) AS ReportsNumber FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY CategoryId, c.Name
ORDER BY ReportsNumber DESC, CategoryName