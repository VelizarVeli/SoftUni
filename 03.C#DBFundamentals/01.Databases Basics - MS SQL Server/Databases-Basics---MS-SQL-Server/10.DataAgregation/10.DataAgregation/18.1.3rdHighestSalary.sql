SELECT DISTINCT DepartmentID, Salary FROM(
SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
FROM Employees
) AS e
WHERE SalaryRank = 3