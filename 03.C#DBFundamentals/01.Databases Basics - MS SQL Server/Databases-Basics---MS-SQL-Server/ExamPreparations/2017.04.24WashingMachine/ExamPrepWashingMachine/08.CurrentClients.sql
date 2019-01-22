SELECT c.FirstName + ' ' + c.LastName AS Client, DATEDIFF(DAY, IssueDate, '2017/04/24') AS [Days going],j.
Status FROM Clients AS c
INNER JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId