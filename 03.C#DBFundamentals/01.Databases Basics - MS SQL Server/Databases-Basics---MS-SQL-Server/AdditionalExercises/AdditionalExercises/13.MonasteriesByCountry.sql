CREATE TABLE Monasteries(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
	SELECT c.CountryCode
	FROM Countries c
	 INNER JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	 INNER JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryCode
	HAVING COUNT(r.Id) > 3
)

SELECT 
  m.Name AS Monastery, c.CountryName AS Country
FROM 
  Countries c
  JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name