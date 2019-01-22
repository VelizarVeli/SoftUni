SELECT c.[Name], COUNT(h.CityId) AS Hotels FROM Cities AS c
LEFT JOIN Hotels AS h on h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]