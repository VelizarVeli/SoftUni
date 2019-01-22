SELECT Manufacturer, AVG(Consumption) AS AverageConsumption FROM Models
WHERE Consumption BETWEEN 5 AND 15 AND Id IN 
(
SELECT TOP(7) m.Id FROM Orders AS o
JOIN Vehicles AS v ON v.Id = o.VehicleId
JOIN Models AS m ON m.Id = v.ModelId
GROUP BY m.Id
ORDER BY COUNT(o.VehicleId) DESC)
GROUP BY Manufacturer
ORDER BY Manufacturer,
         AverageConsumption; 