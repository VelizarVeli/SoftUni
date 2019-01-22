SELECT c.CountryCode, COUNT(mc.MountainId) AS MountainRanges FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m
ON mc.MountainId = m.Id
GROUP BY c.CountryCode
HAVING c.CountryCode IN('US', 'RU', 'BG')