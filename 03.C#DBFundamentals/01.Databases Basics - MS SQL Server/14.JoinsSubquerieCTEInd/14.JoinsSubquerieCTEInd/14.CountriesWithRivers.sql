SELECT TOP 5 c.CountryName, r.RiverName FROM Rivers AS r
JOIN CountriesRivers AS rc
ON r.Id = rc.RiverId
RIGHT OUTER JOIN Countries AS c
ON c.CountryCode = rc.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName