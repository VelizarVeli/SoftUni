SELECT g.[Name] AS Game, gt.[Name] AS [Game Type], u.Username, ug.Level, ug.Cash, c.Name FROM Games AS g
INNER JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
INNER JOIN UsersGames AS ug ON g.Id = ug.GameId
INNER JOIN Users AS u ON ug.UserId = u.Id
INNER JOIN Characters AS c ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, Username, Game