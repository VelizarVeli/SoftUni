CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum DECIMAL (10,2),
NewSum DECIMAL (10,2)
)

CREATE TRIGGER tr_AccountChangesLogs ON Accounts AFTER UPDATE 
AS
BEGIN
	INSERT Logs(AccountId, OldSum, NewSum)
	SELECT inserted.Id, deleted.Balance, inserted.Balance
	FROM deleted, inserted
END