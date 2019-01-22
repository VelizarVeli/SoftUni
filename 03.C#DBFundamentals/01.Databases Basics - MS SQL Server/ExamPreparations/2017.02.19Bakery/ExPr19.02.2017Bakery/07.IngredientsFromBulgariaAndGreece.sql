SELECT TOP(15) i.Name, Description, c.Name FROM Ingredients AS i
INNER JOIN Countries AS c ON c.Id = i.OriginCountryId
WHERE c.Name IN('Bulgaria','Greece')
ORDER BY i.Name, c.Name