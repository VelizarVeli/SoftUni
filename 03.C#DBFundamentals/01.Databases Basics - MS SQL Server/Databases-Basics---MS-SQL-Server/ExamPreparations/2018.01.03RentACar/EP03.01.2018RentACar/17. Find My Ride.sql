CREATE FUNCTION udf_CheckForVehicle(@townName VARCHAR (50), @seatsNumber VARCHAR (50)) 
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @result VARCHAR(MAX) = (SELECT TOP(1) CONCAT(o.Name,' - ', m.Model)  FROM Offices AS o
JOIN Towns AS t ON t.Id = o.TownId
JOIN Vehicles AS v ON v.OfficeId = o.Id
JOIN Models AS m ON m.Id = v.ModelId
WHERE t.Name = @townName AND m.Seats = @seatsNumber
ORDER BY o.Name)
IF(@result IS NULL)
BEGIN
SET @result = 'NO SUCH VEHICLE FOUND'
END RETURN @result
END