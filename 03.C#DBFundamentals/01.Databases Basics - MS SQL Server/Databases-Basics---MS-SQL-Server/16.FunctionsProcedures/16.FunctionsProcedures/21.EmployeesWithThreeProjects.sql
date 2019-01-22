CREATE PROCEDURE usp_AssignProject(@emloyeeID INT, @ProjectID INT)
AS
BEGIN
	DECLARE @MaxProjectsPerEmployee INT = 3
	DECLARE @EmplojeeProjectCount INT
			BEGIN TRAN
			INSERT EmployeesProjects (EmployeeID, ProjectID)
			VALUES
			(@emloyeeID, @ProjectID)

			SET @EmplojeeProjectCount = (SELECT COUNT(*) FROM EmployeesProjects
										WHERE EmployeeID = @emloyeeID
									)
			IF(@EmplojeeProjectCount > @MaxProjectsPerEmployee)
			BEGIN
				RAISERROR('The employee has too many projects!',16,1)
				ROLLBACK
			END
			ELSE
			BEGIN
				COMMIT
			END
END