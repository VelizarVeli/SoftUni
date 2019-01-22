SELECT CountryName, con.[ContinentName], COUNT(cr.RiverId) AS RiversCount, ISNULL(SUM(r.Length),0) AS TotalLength 
FROM Countries AS c
LEFT JOIN Continents AS con ON con.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName, con.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName