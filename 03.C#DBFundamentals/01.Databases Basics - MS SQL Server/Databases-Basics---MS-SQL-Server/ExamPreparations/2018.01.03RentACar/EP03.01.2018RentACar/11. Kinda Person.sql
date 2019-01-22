SELECT Names, Class
FROM
(
    SELECT c.Id,
           c.firstName+' '+c.lastName AS Names,
           m.class,
           DENSE_RANK() OVER(PARTITION BY c.id ORDER BY COUNT(m.class) DESC) AS [Rank]
    FROM Clients AS c
         JOIN Orders AS o ON o.ClientId = c.Id
         JOIN Vehicles AS v ON v.Id = o.VehicleId
         JOIN Models AS m ON m.id = v.ModelId
    GROUP BY c.id,
             c.FirstName,
             c.LastName,
             m.Class
) AS sorted
WHERE sorted.Rank = 1
ORDER BY Names;