DELETE FROM Locations
WHERE Id IN
(
    SELECT l.Id
    FROM Users AS u
         RIGHT JOIN Locations AS l ON l.Id = u.LocationId
    WHERE u.Id IS NULL
);