SELECT FirstName + ' '+ LastName AS Mechanic, Status, IssueDate FROM Mechanics AS m
INNER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, IssueDate, JobId