SELECT u.Username, g.Name AS Game, COUNT(ugi.ItemId) AS [Items Count], SUM(i.Price) AS [Items Price] FROM Users AS u
INNER JOIN UsersGames AS ug ON u.Id = ug.UserId
INNER JOIN Games AS g ON ug.GameId = g.Id
INNER JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
INNER JOIN Items AS i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username