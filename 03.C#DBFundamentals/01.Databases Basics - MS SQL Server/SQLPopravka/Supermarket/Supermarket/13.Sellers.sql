SELECT TOP(10) CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], SUM(i.Price * oi.Quantity) AS [Total Price],
COUNT(oi.ItemId) AS Items
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.[DateTime] < '2018-06-15'
GROUP BY CONCAT(e.FirstName, ' ', e.LastName),o.[DateTime]
--HAVING o.[DateTime] < '2018-06-15'
ORDER BY SUM(i.Price * oi.Quantity) DESC, COUNT(oi.ItemId) 