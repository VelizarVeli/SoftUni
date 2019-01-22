WITH CTE_CountriesHighestElevation AS
(
	SELECT c.CountryName,
		CASE 
			WHEN MAX(p.Elevation) IS NULL THEN 0
			ELSE MAX(p.Elevation)
		END AS [Highest Peak Elevation] FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks As p
	ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName
),

CTE_MountainHighestElevation AS
(
	SELECT m.Id, MAX(p.Elevation) AS mhe FROM Mountains AS m
	JOIN Peaks AS p
	ON p.MountainId = m.Id
	GROUP BY m.Id
)

SELECT TOP 5
	he.CountryName AS Country,
	CASE
		WHEN p.PeakName IS NULL THEN '(no highest peak)'
		ELSE p.PeakName
	END AS [Highest Peak Name],

	he.[Highest Peak Elevation],
	CASE
		WHEN m.MountainRange IS NULL THEN '(no mountain)'
		ELSE m.MountainRange
	END AS Mountain

FROM CTE_CountriesHighestElevation As he
JOIN Countries AS c
ON c.CountryName = he.CountryName
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN CTE_MountainHighestElevation AS mh
ON mh.Id = mc.MountainId AND mh.mhe = [Highest Peak Elevation]
LEFT JOIN Peaks AS p
ON p.Elevation = mh.mhe
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE he.[Highest Peak Elevation] = p.Elevation OR he.[Highest Peak Elevation] = 0
ORDER BY he.CountryName