CREATE PROC usp_AssignEmployeeToReport @employeeId INT, @reportId INT
AS 
BEGIN
	DECLARE @employeeDep INT = (SELECT e.DepartmentId FROM Employees AS e
	WHERE e.Id = @employeeId)

	DECLARE @reportDep INT = (SELECT c.DepartmentId FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE r.Id = @reportId)

	IF(@employeeDep = @reportDep)
	BEGIN
	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId
	END
	ELSE
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	END
END
