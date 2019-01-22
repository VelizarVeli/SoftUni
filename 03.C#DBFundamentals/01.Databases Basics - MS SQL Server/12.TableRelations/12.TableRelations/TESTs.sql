SELECT MountainRange, PeakName, Elevation FROM Peaks AS p
INNER JOIN Mountains AS m ON m.Id = p.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

SELECT * FROM Peaks