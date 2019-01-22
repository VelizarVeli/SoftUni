WITH AVGStats_CTE (AVGSpeed, AVGLuck, AVGMind)
AS
(
SELECT AVG(st.Speed) AS AVGSpeed, AVG(st.Luck) AS AVGLuck, AVG(st.Mind) AS AVGMind 
FROM [Statistics] as st
)

SELECT i.Name, i.Price, i.MinLevel, ista.Strength, ista.Defence, ista.Speed, ista.Luck, ista.Mind
FROM Items AS i
INNER JOIN [Statistics] AS ista
ON ista.Id = i.StatisticId
WHERE ista.Speed > (SELECT AVGSpeed FROM AVGStats_CTE) AND
		ista.Luck > (SELECT AVGLuck FROM AVGStats_CTE) AND
		ista.Mind > (SELECT AVGMind FROM AVGStats_CTE)
ORDER BY i.Name