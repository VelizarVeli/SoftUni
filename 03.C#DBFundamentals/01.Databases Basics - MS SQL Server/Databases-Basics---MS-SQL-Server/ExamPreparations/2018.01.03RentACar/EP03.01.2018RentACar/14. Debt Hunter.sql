SELECT tab.FirstName+' '+tab.LastName AS CategoryName,
       tab.Email AS Email,
       tab.Bill AS Bill,
       tab.Name AS Town
FROM
(
    SELECT c.Id,
           c.FirstName,
           c.LastName,
           c.Email,
           o.Bill,
           t.Name,
           DENSE_RANK() OVER(PARTITION BY t.name ORDER BY(o.bill) DESC) AS [Rank]
    FROM Clients AS c
         JOIN Orders AS o ON o.ClientId = c.Id
         JOIN Towns AS t ON t.id = o.TownId
    WHERE c.CardValidity < o.CollectionDate
          AND bill IS NOT NULL
    GROUP BY t.Name,
             o.Bill,
             c.Id,
             c.Email,
             c.FirstName,
             c.LastName
) AS tab
WHERE Rank <= 2
ORDER BY Town,
         bill,
         tab.id;