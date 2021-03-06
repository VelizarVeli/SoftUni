SELECT a.DepartmentId,
(
	SELECT DISTINCT b.Salary FROM Employees AS b
	WHERE b.DepartmentID = a.DepartmentId
	ORDER BY Salary DESC
	OFFSET 2 ROWS
	FETCH NEXT 1 ROWS ONLY
) AS [ThirdHighestSalary]
FROM Employees AS a
WHERE (
	SELECT DISTINCT b.Salary FROM Employees AS b
	WHERE b.DepartmentID = a.DepartmentId
	ORDER BY Salary DESC
	OFFSET 2 ROWS
	FETCH NEXT 1 ROWS ONLY
) IS NOT NULL
GROUP BY a.DepartmentID