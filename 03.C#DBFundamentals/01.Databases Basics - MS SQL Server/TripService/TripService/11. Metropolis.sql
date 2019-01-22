SELECT TOP 5 C.Id, C.Name AS City, C.CountryCode AS Country, COUNT(*) AS Accounts FROM Cities C
JOIN Accounts A on C.Id = A.CityId
GROUP BY C.Id, C.Name, C.CountryCode
ORDER BY Accounts DESC, C.Id