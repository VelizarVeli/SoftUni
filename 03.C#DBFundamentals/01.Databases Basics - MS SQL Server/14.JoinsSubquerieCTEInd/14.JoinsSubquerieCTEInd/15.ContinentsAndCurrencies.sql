WITH CTE_ContinentMax (ContinentCode, CurrencyUsage) AS
(
	SELECT ContinentCode, MAX(c) AS CurrencyUsage FROM
	(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS c FROM Countries
	GROUP BY ContinentCode, CurrencyCode) AS k
	GROUP BY ContinentCode
),

CTE_AllCurrCont (ContinentCode, CurrencyCode, CurrencyUsage) AS
(
	SELECT * FROM
	(SELECT ContinentCode, CurrencyCode, MAX(c) AS CurrencyUsage FROM
		(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS c FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS t
	GROUP BY ContinentCode, CurrencyCode) AS m
)

SELECT acc.ContinentCode, acc.CurrencyCode, acc.CurrencyUsage FROM CTE_AllCurrCont AS acc
JOIN CTE_ContinentMax AS cm
ON cm.ContinentCode = acc.ContinentCode AND cm.CurrencyUsage = acc.CurrencyUsage
WHERE acc.CurrencyUsage > 1
ORDER BY acc.ContinentCode