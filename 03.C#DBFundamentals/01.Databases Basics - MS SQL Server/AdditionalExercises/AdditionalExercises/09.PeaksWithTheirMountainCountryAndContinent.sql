SELECT PeakName, m.MountainRange AS Mountain, CountryName, ContinentName FROM Peaks AS p
INNER JOIN Mountains AS m ON m.Id = p.MountainId
INNER JOIN MountainsCountries AS ms ON ms.MountainId = m.Id
INNER JOIN Countries AS c ON c.CountryCode = ms.CountryCode
INNER JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName