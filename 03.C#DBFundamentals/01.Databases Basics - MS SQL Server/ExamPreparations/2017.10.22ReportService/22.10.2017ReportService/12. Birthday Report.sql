SELECT DISTINCT c.Name AS [Category Name] FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE DATEPART(DAY, u.BirthDate) = DATEPART(DAY,r.OpenDate) 
AND DATEPART(MONTH, u.BirthDate) = DATEPART(MONTH,r.OpenDate)
ORDER BY [Category Name]