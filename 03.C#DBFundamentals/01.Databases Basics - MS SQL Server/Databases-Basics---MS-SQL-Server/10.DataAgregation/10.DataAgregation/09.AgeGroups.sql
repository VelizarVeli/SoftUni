SELECT *, COUNT(*) AS WizzardCount FROM 
(SELECT 
	CASE 
	 WHEN Age <= 10 THEN '[0-10]'
	 WHEN Age Between 11 AND 20 THEN '[11-20]'
	 WHEN Age Between 21 AND 30 THEN '[21-30]'
	 WHEN Age Between 31 AND 40 THEN '[31-40]'
	 WHEN Age Between 41 AND 50 THEN '[41-50]'
	 WHEN Age Between 51 AND 60 THEN '[51-60]'
	 ELSE '[61+]'
END AS AgeGroup
FROM WizzardDeposits)
AS t
GROUP BY AgeGroup
ORDER BY AgeGroup