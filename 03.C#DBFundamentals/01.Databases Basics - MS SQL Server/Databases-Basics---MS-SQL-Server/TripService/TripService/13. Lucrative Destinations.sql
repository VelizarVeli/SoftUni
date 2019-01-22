SELECT TOP 10
  C.Id,
  C.Name,
  SUM(H.BaseRate + R.Price) AS [Total Revenue],
  COUNT(*)                  AS Trips
FROM Cities C
  JOIN Hotels H on C.Id = H.CityId
  JOIN Rooms R on H.Id = R.HotelId
  JOIN Trips T on R.Id = T.RoomId
WHERE YEAR(T.BookDate) = 2016
GROUP BY C.Id, C.Name
ORDER BY [Total Revenue] DESC, Trips DESC