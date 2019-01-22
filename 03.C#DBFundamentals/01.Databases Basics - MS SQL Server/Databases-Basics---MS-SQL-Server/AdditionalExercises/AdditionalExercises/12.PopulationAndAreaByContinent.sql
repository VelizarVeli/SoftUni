SELECT ContinentName, SUM(AreaInSqKm) AS CountriesArea, SUM(CONVERT(bigint, Population)) AS CountriesPopulation
FROM Continents AS con
LEFT JOIN Countries AS c ON c.ContinentCode = con.ContinentCode
GROUP BY ContinentName
ORDER BY CountriesPopulation DESC