CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
  BEGIN
    DECLARE @SourceHotelId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                    JOIN Trips T on R.Id = T.RoomId
                                  WHERE T.Id = @TripId)

    DECLARE @TargetHotelId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                  WHERE R.Id = @TargetRoomId)

    IF (@SourceHotelId <> @TargetHotelId)
      THROW 50013, 'Target room is in another hotel!', 1

    DECLARE @PeopleCount INT = (SELECT COUNT(*)
                                FROM AccountsTrips
                                WHERE TripId = @TripId)

    DECLARE @TargetRoomBeds INT = (SELECT Beds
                                   FROM Rooms
                                   WHERE Id = @TargetRoomId)

    IF (@PeopleCount > @TargetRoomBeds)
      THROW 50013, 'Not enough beds in target room!', 1

    UPDATE Trips
    SET RoomId = @TargetRoomId
    WHERE Id = @TripId
  END