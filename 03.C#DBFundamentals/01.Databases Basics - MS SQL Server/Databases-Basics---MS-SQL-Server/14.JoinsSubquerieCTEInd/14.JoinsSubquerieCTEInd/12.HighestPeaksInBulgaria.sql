SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m
ON mc.MountainId = m.Id
INNER JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2834
ORDER BY Elevation DESC