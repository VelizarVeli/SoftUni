WITH CTE_CountryHighestPeak AS
(
	SELECT c.CountryName, MAX(p.Elevation) AS HighestPeakElevation FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks AS p
	ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName
),

CTE_CountryLongestRiver AS
(
	SELECT c.CountryName, MAX(r.Length) AS LongestRiverLength FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
	GROUP BY c.CountryName
)

SELECT TOP(5) hp.CountryName, hp.HighestPeakElevation, lr.LongestRiverLength FROM CTE_CountryHighestPeak AS hp
JOIN CTE_CountryLongestRiver AS lr
ON lr.CountryName = hp.CountryName
ORDER BY hp.HighestPeakElevation DESC, lr.LongestRiverLength DESC