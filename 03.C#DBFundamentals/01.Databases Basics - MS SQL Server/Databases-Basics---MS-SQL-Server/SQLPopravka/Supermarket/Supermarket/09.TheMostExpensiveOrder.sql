SELECT TOP(1) OrderId, SUM(i.Price * oi.Quantity) FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY OrderId
ORDER BY SUM(i.Price * oi.Quantity) DESC