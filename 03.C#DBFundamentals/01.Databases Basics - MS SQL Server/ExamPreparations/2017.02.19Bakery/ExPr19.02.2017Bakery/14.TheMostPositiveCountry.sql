SELECT TOP(1) WITH TIES cs.Name, AVG(Rate) AS FeedbackRate FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
JOIN Countries AS cs ON cs.Id = c.CountryId
GROUP BY cs.Name
ORDER BY FeedbackRate DESC