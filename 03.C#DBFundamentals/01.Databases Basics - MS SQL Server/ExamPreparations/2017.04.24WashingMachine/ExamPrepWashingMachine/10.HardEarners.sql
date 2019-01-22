SELECT TOP(3) FirstName + ' ' + LastName AS Mechanic, 
COUNT(j.Status) AS Jobs FROM Mechanics AS m
JOIN Jobs j ON j.MechanicId = m.MechanicId
WHERE j.Status <> 'Finished'
GROUP BY m.MechanicId, FirstName + ' ' + LastName
HAVING COUNT(*) > 1
ORDER BY Jobs DESC, m.MechanicId