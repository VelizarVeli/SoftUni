SELECT SUM(Difference) FROM (
SELECT Wiz1.FirstName AS [Host Wizzard], Wiz1.DepositAmount AS [Host Wizzard Deposit],
	Wiz2.FirstName AS [Guest Wizzard], Wiz2.DepositAmount AS [Guest Wizzard Deposit],
	Wiz1.DepositAmount - Wiz2.DepositAmount AS Difference
  FROM WizzardDeposits AS Wiz1
INNER JOIN WizzardDeposits AS Wiz2
ON Wiz1.Id = Wiz2.Id - 1) AS t