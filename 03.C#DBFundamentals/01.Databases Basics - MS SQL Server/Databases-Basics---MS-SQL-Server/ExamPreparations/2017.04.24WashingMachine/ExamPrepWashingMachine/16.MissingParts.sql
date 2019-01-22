SELECT p.PartId, p.[Description], SUM(pn.Quantity) AS Required, AVG(p.StockQTY) AS 'In Stock',
ISNULL(SUM(op.Quantity), 0) AS Ordered
FROM Parts AS p
INNER JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
INNER JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.[Status] <> 'Finished'
GROUP BY p.PartId, p.[Description]
HAVING SUM(pn.Quantity) > AVG(p.StockQTY) + ISNULL(SUM(op.Quantity), 0)
ORDER BY p.PartId