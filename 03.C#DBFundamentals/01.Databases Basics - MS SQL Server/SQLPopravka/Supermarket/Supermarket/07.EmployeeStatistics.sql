SELECT FirstName, LastName, COUNT(*) AS [Count] FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName, o.EmployeeId
ORDER BY [Count] DESC, FirstName