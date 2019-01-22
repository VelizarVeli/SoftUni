SELECT m.Manufacturer, m.Model, ISNULL(COUNT(o.VehicleId), 0) AS TimesOrdered FROM Vehicles AS v
JOIN Models AS m ON v.ModelId = m.Id
FULL JOIN Orders AS o ON o.VehicleId = v.Id
GROUP BY m.Id, m.Model, m.Manufacturer
ORDER BY TimesOrdered DESC, m.Manufacturer DESC, m.Model