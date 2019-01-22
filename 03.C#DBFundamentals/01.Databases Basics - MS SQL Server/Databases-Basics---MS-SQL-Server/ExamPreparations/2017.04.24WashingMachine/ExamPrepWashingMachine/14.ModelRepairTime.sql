SELECT m.ModelId, m.Name, CAST(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS VARCHAR(10)) + ' days'
 AS [Average Service Time] FROM Models AS m
INNER JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY [Average Service Time]