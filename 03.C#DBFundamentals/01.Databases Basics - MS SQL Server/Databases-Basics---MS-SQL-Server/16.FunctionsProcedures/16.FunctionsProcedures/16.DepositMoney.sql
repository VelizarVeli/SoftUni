CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRAN
	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Accounts.Id = @accountId
		BEGIN
			COMMIT
		END