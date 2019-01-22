--   ??????? ?? ??????

WITH NotReturned
     AS (
     SELECT VehicleId
     FROM Orders
     WHERE ReturnDate IS NULL)

     SELECT m.Model,
            m.Seats,
            v.Mileage
     FROM Vehicles AS v
          JOIN Models AS m ON m.Id = v.ModelId
     WHERE v.Id != ALL
(
    SELECT *
    FROM NotReturned
)
     ORDER BY v.Mileage ASC,
              m.Seats DESC,
              v.ModelId ASC;


--			???, ?????? ????
--SELECT m.Model, m.Seats, v.Mileage FROM Vehicles AS v
--LEFT JOIN Orders AS o ON o.VehicleId = v.Id
--LEFT JOIN Models AS m ON m.Id = v.ModelId
--WHERE o.ReturnDate IS NULL
--ORDER BY v.Mileage, Seats DESC, v.ModelId
--
--SELECT m.Model, m.Seats, v.Mileage FROM Models AS m
-- RIGHT JOIN Vehicles AS v ON m.Id = v.ModelId
-- RIGHT JOIN Orders AS o ON v.Id = o.VehicleId
--  WHERE o.ReturnDate IS NOT NULL
-- ORDER BY v.Mileage ASC, m.Seats DESC, v.ModelId ASC;


 