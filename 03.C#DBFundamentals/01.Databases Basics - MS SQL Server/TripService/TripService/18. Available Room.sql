CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
  RETURNS VARCHAR(MAX)
AS
  BEGIN
    DECLARE @BookedRooms TABLE(Id INT)
    INSERT INTO @BookedRooms
      SELECT DISTINCT R.Id
      FROM Rooms R
        LEFT JOIN Trips T on R.Id = T.RoomId
      WHERE R.HotelId = @HotelId AND @Date BETWEEN T.ArrivalDate AND T.ReturnDate AND T.CancelDate IS NULL

    DECLARE @Rooms TABLE(Id INT, Price DECIMAL(15, 2), Type VARCHAR(20), Beds INT, TotalPrice DECIMAL(15, 2))
    INSERT INTO @Rooms
      SELECT TOP 1
        R.Id,
        R.Price,
        R.Type,
        R.Beds,
        @People * (H.BaseRate + R.Price) AS TotalPrice
      FROM Rooms R
        LEFT JOIN Hotels H on R.HotelId = H.Id
      WHERE
        R.HotelId = @HotelId AND
        R.Beds >= @People AND
        R.Id NOT IN (SELECT Id
                     FROM @BookedRooms)
      ORDER BY TotalPrice DESC

    DECLARE @RoomCount INT = (SELECT COUNT(*)
                              FROM @Rooms)
    IF (@RoomCount < 1)
      BEGIN
        RETURN 'No rooms available'
      END

    DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', Type, ' (', Beds, ' beds) - ', '$', TotalPrice)
                                    FROM @Rooms)

    RETURN @Result
  END