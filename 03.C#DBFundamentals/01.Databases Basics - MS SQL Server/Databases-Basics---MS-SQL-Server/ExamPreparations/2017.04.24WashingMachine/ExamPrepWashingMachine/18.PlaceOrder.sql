CREATE PROC usp_PlaceOrder @JobId INT, @SerialNumber VARCHAR(50), @Quantity INT
AS 
BEGIN
	DECLARE @JobStatus VARCHAR(11) = (SELECT Status FROM Jobs WHERE JobId = @JobId)
	IF (@JobStatus = 'Finished')
	BEGIN
		RAISERROR('This job is not active!', 16, 1);
		RETURN;
	END

	IF (@Quantity <= 0)
	BEGIN
		RAISERROR('Part quantity must be more than zero!', 16, 1);
		RETURN
	END

	DECLARE @JobId INT = (SELECT @@ROWCOUNT FROM Jobs WHERE JobId = 1)
	IF (@DoesJobExist IS NULL)
	BEGIN
		RAISERROR('Job not found!', 16, 1);
		RETURN;
	END
END