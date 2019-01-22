SELECT cur.CurrencyCode, MIN(cur.Description) AS Currency, COUNT(c.CountryName) AS NumberOfCountries 
FROM Currencies AS cur
LEFT JOIN Countries AS c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
ORDER BY NumberOfCountries DESC, Currency