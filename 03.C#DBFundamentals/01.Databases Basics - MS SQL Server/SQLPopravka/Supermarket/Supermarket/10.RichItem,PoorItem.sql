SELECT TOP(10) o.Id, MAX(i.Price) AS ExpensivePrice, MIN(i.Price) AS CheapPrice FROM Items AS i
JOIN OrderItems AS oi ON oi.ItemId = i.Id
JOIN Orders AS o ON o.Id = oi.OrderId
GROUP BY o.Id
ORDER BY MAX(i.Price) DESC, o.Id