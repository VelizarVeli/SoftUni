CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@inputNumber DECIMAL(15,4))
    AS
	BEGIN
		WITH CTE_AccountHolderBalance (AccountHolderId, Balance) AS(
		SELECT AccountHolderId, SUM(Balance) AS TotalBalance
		FROM Accounts
		GROUP BY AccountHolderId)

		SELECT FirstName, LastName
		FROM AccountHolders AS ah
		JOIN CTE_AccountHolderBalance AS acch ON acch.AccountHolderId = ah.Id
		WHERE acch.Balance > @inputNumber
		ORDER BY ah.LastName, ah.FirstName
	END
