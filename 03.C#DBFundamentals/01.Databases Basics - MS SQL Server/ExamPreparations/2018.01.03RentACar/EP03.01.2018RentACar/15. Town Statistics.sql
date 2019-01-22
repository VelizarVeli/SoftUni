SELECT ttt.Name,
       CASE
           WHEN MalePercent = '0'
           THEN NULL
           ELSE MalePercent
       END AS MalePercent,
       CASE
           WHEN ttt.FemalePercent = '0'
           THEN NULL
           ELSE FemalePercent
       END AS FemalePercent
FROM
(
    SELECT t.name,
           CAST((100*SUM(CASE
                             WHEN c.gender = 'M'
                             THEN 1
                             ELSE 0
                         END)/COUNT(*)) AS INT) AS MalePercent,
           CAST((100*SUM(CASE
                             WHEN c.gender = 'F'
                             THEN 1
                             ELSE 0
                         END)/COUNT(*)) AS VARCHAR(3)) AS FemalePercent
    FROM Orders AS o
         JOIN Towns AS t ON o.TownId = t.Id
         JOIN Clients AS c ON c.Id = o.ClientId
    GROUP BY t.name
) AS ttt;