UPDATE Tickets
SET Price = Price * 1.5
WHERE FlightID IN (SELECT FlightID FROM Flights
					WHERE AirlineID = (SELECT TOP (1) AirlineID FROM Airlines
										ORDER BY Rating DESC))
