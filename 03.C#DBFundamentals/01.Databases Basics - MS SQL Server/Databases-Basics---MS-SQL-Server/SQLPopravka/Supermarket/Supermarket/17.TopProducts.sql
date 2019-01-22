SELECT i.[Name], c.[Name], SUM(oi.Quantity) AS [Count], SUM(i.Price * oi.Quantity) AS TotalPrice FROM Items AS i
JOIN Categories AS c ON c.Id = i.CategoryId
JOIN OrderItems AS oi ON oi.ItemId = i.Id
JOIN Orders AS o ON o.Id = oi.OrderId
GROUP BY i.[Name], c.[Name]
ORDER BY SUM(i.Price * oi.Quantity) DESC,  COUNT(oi.ItemId)