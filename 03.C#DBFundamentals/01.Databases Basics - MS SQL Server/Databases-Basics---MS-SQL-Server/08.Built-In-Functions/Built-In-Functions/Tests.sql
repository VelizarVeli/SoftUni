SELECT [Name] AS Game, [Part of the Day] = 
CASE 
	WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) >= 12 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) >= 18 THEN 'Evening'
END,
Duration = 
CASE
	WHEN Duration <= 3 THEN 'Extra short'
	WHEN Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'

	END
AS [Duration] FROM Games
ORDER BY [Name], Duration

SELECT * FROM Games