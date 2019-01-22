CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
RETURNS @RtnTable TABLE
(
SumCash MONEY
)
AS
	BEGIN
	DECLARE @CashSum MONEY

	SET @CashSum =  (SELECT SUM(ug.Cash) AS 'SumCash'
	FROM (
			SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RoWNum
			FROM UsersGames
			WHERE GameId = (SELECT Id FROM Games WHERE Name = @GameName)
		 ) AS ug
	WHERE ug.RoWNum % 2 != 0
	)

	INSERT @RtnTable SELECT @CashSum
	RETURN
END