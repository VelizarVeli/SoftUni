CREATE PROC usp_GetTownsStartingWith(@Text VARCHAR(50))
AS 
SELECT Name
FROM Towns
WHERE LEFT(Name, LEN(@Text)) = @Text