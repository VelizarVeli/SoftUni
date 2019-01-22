SELECT d.Name AS [Department Name], 
ISNULL(CONVERT(VARCHAR(10),AVG(DATEDIFF(DAY, OpenDate, CloseDate))), 'no info') AS [Average Duration] 
FROM Departments AS d
LEFT JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Name
ORDER BY d.Name