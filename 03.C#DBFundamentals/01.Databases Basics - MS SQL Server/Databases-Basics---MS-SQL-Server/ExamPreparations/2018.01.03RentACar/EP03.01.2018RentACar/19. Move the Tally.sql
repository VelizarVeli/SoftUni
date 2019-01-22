CREATE TRIGGER TR_AddMileage ON Orders AFTER UPDATE
 AS
	DECLARE @startMileage INT = (SELECT TotalMileage FROM deleted)
	 IF (@startMileage IS NULL)
	  BEGIN
		DECLARE @vehicleId INT = (SELECT VehicleId FROM inserted)
		DECLARE @mileage INT = (SELECT TotalMileage FROM inserted)

		UPDATE Vehicles 
		SET Mileage +=@mileage
		WHERE Id = @vehicleId
	  END