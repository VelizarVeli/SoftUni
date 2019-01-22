DECLARE @AlexUserGameId  INT = (
								SELECT Id 
								FROM UsersGames AS ug
								WHERE ug.GameId = 
									  (SELECT Id FROM Games WHERE Name = 'Edinburgh') AND
									  ug.UserId =
									  (SELECT Id FROM Users WHERE Username = 'Alex')
								)

DECLARE @AlexItemsPrice MONEY = (
								SELECT SUM(Price) FROM Items
								WHERE Name IN ('Blackguard', 
								'Bottomless Potion of Amplification', 
								'Eye of Etlich (Diablo III)', 
								'Gem of Efficacious Toxin', 
								'Golden Gorget of Leoric', 
								'Hellfire Amulet')
								)

DECLARE @GameID INT = (Select GameId FROM UsersGames WHERE Id = @AlexUserGameId)

INSERT UserGameItems
SELECT it.Id, @AlexUserGameId
FROM Items AS it
WHERE it.Name IN ('Blackguard', 
					'Bottomless Potion of Amplification', 
					'Eye of Etlich (Diablo III)', 
					'Gem of Efficacious Toxin', 
					'Golden Gorget of Leoric', 
					'Hellfire Amulet')

UPDATE UsersGames
SET Cash = Cash - @AlexItemsPrice
WHERE Id = @AlexUserGameId

SELECT us.Username, ga.Name, ug.Cash, its.Name AS [Item Name]
FROM Users AS us
INNER JOIN UsersGames AS ug
ON ug.UserId = us.Id
INNER JOIN Games AS ga
ON ga.Id = ug.GameId
INNER JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
INNER JOIN Items AS its
ON its.Id = ugi.ItemId
WHERE ug.GameId = @GameID
ORDER BY [Item Name]