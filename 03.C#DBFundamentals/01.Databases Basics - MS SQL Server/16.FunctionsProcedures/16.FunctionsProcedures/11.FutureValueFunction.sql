	CREATE FUNCTION ufn_CalculateFutureValue(@initialSum MONEY, @yearlyInterestRate FLOAT, @numberOfYears INT)
	RETURNS	MONEY
	AS
	   BEGIN
		 RETURN @initialSum * (POWER(1 + @yearlyInterestRate, @numberOfYears));	
	END

	EXEC dbo.ufn_CalculateFutureValue(132$, 4, 5)