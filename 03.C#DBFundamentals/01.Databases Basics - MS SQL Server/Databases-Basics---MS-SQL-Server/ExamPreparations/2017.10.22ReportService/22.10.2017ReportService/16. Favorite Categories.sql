SELECT Department, Category, [Percentage]
FROM (SELECT D.Name AS Department, C.Name AS Category,
CAST(ROUND(COUNT(1) OVER(PARTITION BY C.Id) * 100.00 / COUNT(1) OVER(PARTITION BY D.Id), 0) AS INT) AS [Percentage]
     FROM Categories AS C
		  JOIN Reports AS R ON R.Categoryid = C.Id
		  JOIN Departments AS D ON D.Id = C.Departmentid) AS [Stats]
GROUP BY Department, Category, [Percentage]
ORDER BY Department, Category, [Percentage];


SELECT d.Name AS [Department Name], c.Name AS [Category Name], 
CONVERT(INT, ROUND(CountPerCategory.Count * 100.0 / CountPerDepartment.Count, 0)) AS Percentage
FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN (SELECT CategoryId, COUNT(1) AS Count
FROM Reports
GROUP BY CategoryId) CountPerCategory ON CountPerCategory.CategoryId = c.Id
JOIN (SELECT c.DepartmentId, COUNT(1) AS Count
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.DepartmentId) CountPerDepartment ON CountPerDepartment.DepartmentId = c.DepartmentId
ORDER BY d.Name, c.Name, Percentage