SELECT ProductId, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, f.[Description] AS FeedbackDescription
FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
WHERE c.Id IN(
SELECT CustomerId FROM Feedbacks AS f
GROUP BY CustomerId
HAVING COUNT(f.Id) >= 3
)
ORDER BY ProductId, CustomerName, f.Id