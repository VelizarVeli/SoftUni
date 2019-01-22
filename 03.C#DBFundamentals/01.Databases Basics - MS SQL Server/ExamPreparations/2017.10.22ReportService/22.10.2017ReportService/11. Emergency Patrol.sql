SELECT r.OpenDate, r.Description, u.Email AS [Reporter Email] FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
WHERE CloseDate IS NULL AND LEN(Description) > 20 AND Description LIKE '%str%'
	AND CategoryId IN (4, 11, 1, 15, 16)
ORDER BY OpenDate, [Reporter Email] 