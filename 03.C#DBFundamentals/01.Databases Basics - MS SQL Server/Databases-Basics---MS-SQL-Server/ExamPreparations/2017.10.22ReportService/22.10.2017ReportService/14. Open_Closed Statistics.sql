 -- ??????
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name, CONCAT(COUNT(CloseDate),'/',COUNT(OpenDate))
FROM Reports AS r
JOIN Employees AS e ON e.Id = r.EmployeeId
WHERE OpenDate BETWEEN '2016-01-01' AND '2016-12-31'
GROUP BY UserId, CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY Name

--???????? ???????
SELECT E.Firstname+' '+E.Lastname AS FullName, ISNULL(CONVERT(varchar, CC.ReportSum), '0') + '/' +        
       ISNULL(CONVERT(varchar, OC.ReportSum), '0') AS [Stats]
FROM Employees AS E
JOIN (SELECT EmployeeId,  COUNT(1) AS ReportSum
	  FROM Reports R
	  WHERE  YEAR(OpenDate) = 2016
	  GROUP BY EmployeeId) AS OC ON OC.Employeeid = E.Id
LEFT JOIN (SELECT EmployeeId,  COUNT(1) AS ReportSum
	       FROM Reports R
	       WHERE  YEAR(CloseDate) = 2016
	       GROUP BY EmployeeId) AS CC ON CC.Employeeid = E.Id
ORDER BY FullName
