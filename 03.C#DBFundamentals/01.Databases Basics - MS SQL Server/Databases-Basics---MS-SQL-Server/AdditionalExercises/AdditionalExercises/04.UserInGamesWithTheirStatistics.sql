SELECT 
	us.Username AS [Username], 
	ga.Name AS [Game],
	MAX(cha.Name) AS [Character],
	SUM(sta.Strength) + MAX(gtst.Strength) + MAX(chst.Strength) AS [Strength],
	SUM(sta.Defence) + MAX(gtst.Defence) + MAX(chst.Defence) AS [Defence],
	SUM(sta.Speed) + MAX(gtst.Speed) + MAX(chst.Speed) AS [Speed],
	SUM(sta.Mind) + MAX(gtst.Mind) + MAX(chst.Mind) AS [Mind],
	SUM(sta.Luck) + MAX(gtst.Luck) + MAX(chst.Luck) AS [Luck]

FROM Users AS us
INNER JOIN UsersGames AS ug
ON us.Id = ug.UserId
INNER JOIN Games AS ga
ON ug.GameId = ga.Id
INNER JOIN Characters AS cha
ON ug.CharacterId = cha.Id
INNER JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
INNER JOIN Items AS itms
ON ugi.ItemId = itms.Id
INNER JOIN [Statistics] AS sta
ON itms.StatisticId = sta.Id
INNER JOIN GameTypes AS gt
ON ga.GameTypeId = gt.Id
INNER JOIN [Statistics] AS chst
ON cha.StatisticId = chst.Id
INNER JOIN [Statistics] AS gtst
ON gt.BonusStatsId = gtst.Id
GROUP BY us.Username, ga.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

