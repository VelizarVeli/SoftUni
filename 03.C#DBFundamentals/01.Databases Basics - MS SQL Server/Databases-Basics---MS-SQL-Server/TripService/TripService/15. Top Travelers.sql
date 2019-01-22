SELECT
  AccountId,
  Email,
  CountryCode,
  Trips
FROM (SELECT
        A.Id                             AS AccountId,
        A.Email,
        C.CountryCode,
        COUNT(*)                         AS Trips,
        DENSE_RANK()
        OVER ( PARTITION BY C.CountryCode
          ORDER BY COUNT(*) DESC, A.Id ) AS Rank
      FROM Accounts A
        JOIN AccountsTrips AT on A.Id = AT.AccountId
        JOIN Trips T on AT.TripId = T.Id
        JOIN Rooms R on T.RoomId = R.Id
        JOIN Hotels H on R.HotelId = H.Id
        JOIN Cities C on H.CityId = C.Id
      GROUP BY C.CountryCode, A.Email, A.Id) AS RanksPerCountry
WHERE Rank = 1
ORDER BY Trips DESC, AccountId