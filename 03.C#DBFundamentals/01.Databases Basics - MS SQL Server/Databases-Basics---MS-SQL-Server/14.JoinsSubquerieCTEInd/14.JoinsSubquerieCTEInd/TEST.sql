SELECT u.Username, g.Name AS Game, c.Name AS Character FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN Characters AS c ON c.Id = ug.CharacterId

SELECT * FROM Games
ORDER BY Name DESC
