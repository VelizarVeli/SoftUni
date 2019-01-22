CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	DECLARE @SenderBalance MONEY = (SELECT ac.Balance FROM Accounts AS ac WHERE ac.Id = @senderId)
	BEGIN TRAN
		IF(@amount < 0)
		BEGIN
			ROLLBACK
		END
		ELSE
		BEGIN
			IF(@SenderBalance - @amount >= 0)
			BEGIN
				EXEC usp_WithdrawMoney @senderId, @amount
				EXEC usp_DepositMoney @receiverId, @amount
				COMMIT
			END
			ELSE
			BEGIN
				ROLLBACK
			END
		END
END