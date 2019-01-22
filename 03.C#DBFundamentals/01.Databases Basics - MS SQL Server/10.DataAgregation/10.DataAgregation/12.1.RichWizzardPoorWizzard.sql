SELECT SUM(e.Diff) AS TotalSum FROM(
SELECT DepositAmount - LEAD(DepositAmount, 1, 4) OVER (ORDER BY Id) AS Diff
FROM WizzardDeposits
) AS e