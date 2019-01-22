SELECT PeakName, MountainRange AS Mountains, Elevation FROM Peaks AS p
INNER JOIN Mountains AS m ON m.Id = p.MountainId
ORDER BY Elevation DESC, PeakName

SELECT * FROM Peaks