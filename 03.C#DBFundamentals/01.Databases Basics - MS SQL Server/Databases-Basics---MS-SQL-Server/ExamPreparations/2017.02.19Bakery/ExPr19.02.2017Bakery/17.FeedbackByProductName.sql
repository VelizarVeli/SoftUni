CREATE FUNCTION udf_GetRating(@name VARCHAR(50))
RETURNS VARCHAR(9)
AS
BEGIN
DECLARE @rating VARCHAR(9);

DECLARE @AverageRating DECIMAL(4,2) = (SELECT AVG(Rate)
 FROM Feedbacks AS f
JOIN Products AS p ON p.Id = f.ProductId
WHERE p.Name = @name
GROUP BY f.ProductId, p.Name)

	IF(@AverageRating < 5)
	BEGIN
		SET @rating = 'Bad'
	END
	ELSE IF(@AverageRating >= 5 AND @AverageRating < 8)
	BEGIN
		SET @rating = 'Average'
	END
	ELSE
	BEGIN
		SET @rating = 'No rating'
	END
	RETURN @rating
END