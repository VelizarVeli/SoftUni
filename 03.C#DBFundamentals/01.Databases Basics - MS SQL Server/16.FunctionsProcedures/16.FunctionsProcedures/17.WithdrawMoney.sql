CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount MONEY) 
AS
BEGIN DECLARE @CurrentAccountBalance MONEY
BEGIN TRAN
	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Accounts.Id = @accountId
	SET @CurrentAccountBalance = (SELECT Balance FROM Accounts AS a WHERE a.Id = @accountId)
	IF(@CurrentAccountBalance < 0)
	BEGIN
		ROLLBACK
	END
	ELSE
	BEGIN
		COMMIT
	END
END