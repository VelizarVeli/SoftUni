CREATE PROC usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
BEGIN
BEGIN TRANSACTION
UPDATE Vehicles 
SET OfficeId = @officeId
WHERE Id = @vehicleId
IF ((SELECT o.ParkingPlaces - COUNT(v.Id) AS Diff FROM Offices AS o
FULL JOIN Vehicles AS v ON v.OfficeId = o.Id
WHERE OfficeId = 5
GROUP BY o.Name, o.ParkingPlaces) >= 0)
BEGIN
ROLLBACK
RAISERROR('Not enough room in this office!', 16, 1)
RETURN 
END
COMMIT
END

CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId  INT)
AS
     BEGIN
         BEGIN TRANSACTION;
         DECLARE @curentVehicleCount INT = (SELECT COUNT(*) FROM Offices AS O
         JOIN Vehicles AS V ON V.OfficeId = O.Id
		WHERE O.Id = @officeId);
         IF(@curentVehicleCount >= (SELECT ParkingPlaces FROM Offices
        WHERE id = @officeId))
         BEGIN
            RAISERROR('Not enough room in this office!', 16, 1);
            ROLLBACK;
         END;
        UPDATE Vehicles
           SET OfficeId = @officeId
        WHERE id = @vehicleId;
        COMMIT;
     END;