SELECT TOP(10) p.Name, p.Description, AVG(f.Rate) AS AverageRate, COUNT(f.ProductId) AS FeedbacksAmount
 FROM Products AS p
JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY p.Id, p.Name, p.Description
ORDER BY AverageRate DESC, FeedbacksAmount DESC