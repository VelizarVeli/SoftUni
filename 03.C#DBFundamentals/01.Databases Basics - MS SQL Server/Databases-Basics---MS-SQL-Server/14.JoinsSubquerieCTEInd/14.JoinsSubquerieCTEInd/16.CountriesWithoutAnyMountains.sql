WITH CTE_AllCountries AS
(
	SELECT COUNT(*) AS a FROM Countries
),

CTE_CountriesWithMountains AS 
(
	SELECT COUNT(DISTINCT CountryCode) AS b FROM MountainsCountries
)

SELECT a - b AS CountryCode FROM CTE_AllCountries
JOIN CTE_CountriesWithMountains
ON a IS NOT NULL