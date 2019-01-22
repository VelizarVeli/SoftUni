                          
						  --?? ??????
--SELECT DISTINCT Username
--  FROM (SELECT Username, LEFT(Username, 1) AS [FirstChar], RIGHT(Username, 1) AS [LastChar],
--			 r.CategoryId AS [CategoryId]
--        FROM Users AS u
--        JOIN Reports AS r ON u.Id = r.UserId
--       WHERE Username LIKE '[0-9]%' OR Username LIKE '%[0-9]') AS Test
-- WHERE TRY_PARSE(FirstChar AS INT) = CategoryId OR TRY_PARSE(LastChar AS INT) = CategoryId
-- ORDER BY Username;

                           -- ?? ?????? ?????-?????????
 SELECT DISTINCT u.Username FROM Reports AS r
 JOIN Categories AS c ON c.Id = r.CategoryId
 JOIN Users AS u ON u.Id = r.UserId
 WHERE LEFT(u.Username, 1) LIKE '[0-9]' AND CONVERT(VARCHAR(10), c.Id) = LEFT(u.Username, 1)
 OR RIGHT(u.Username, 1) LIKE '[0-9]' AND CONVERT(VARCHAR(10), c.Id) = RIGHT(u.Username, 1)
 ORDER BY u.Username