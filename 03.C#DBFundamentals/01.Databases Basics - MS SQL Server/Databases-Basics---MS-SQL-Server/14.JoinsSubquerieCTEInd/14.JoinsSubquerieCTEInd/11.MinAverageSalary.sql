SELECT MIN(AverageSalaryByDepartment) AS MinAverageSalary FROM (
SELECT AVG(Salary) AS AverageSalaryByDepartment FROM Employees
GROUP BY DepartmentID) AS AVGSalaries