SELECT e.EmployeeID, e.FirstName, 
CASE WHEN p.StartDate >= '2005.01.01' THEN NULL
ELSE p.Name
END AS ProjectName FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24