SELECT m.FirstName + ' ' + m.LastName AS Mechnic, AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName