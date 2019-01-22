SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, c.PhoneNumber, c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id
WHERE f.Description IS NULL AND f.Rate IS NULL
ORDER BY c.Id

-- ??? ??? ???? ??????? ??? JOIN

SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName, PhoneNumber, Gender
FROM Customers
WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)