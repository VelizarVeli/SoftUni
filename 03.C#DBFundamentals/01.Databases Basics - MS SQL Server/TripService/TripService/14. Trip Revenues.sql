SELECT
  AT.TripId,
  H.Name AS HotelName,
  R.Type AS RoomType,
  CASE WHEN T.CancelDate IS NULL
    THEN SUM(H.BaseRate + R.Price)
  ELSE 0
  END    AS Revenue
FROM Trips T
  JOIN Rooms R on T.RoomId = R.Id
  JOIN Hotels H on R.HotelId = H.Id
  JOIN AccountsTrips AT on T.Id = AT.TripId
GROUP By AT.TripId, H.Name, R.Type, T.CancelDate
ORDER BY RoomType, AT.TripId