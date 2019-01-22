INSERT INTO Messages(Content, SentOn, ChatId, UserId)
       SELECT CONCAT(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude) AS Content,
              CONVERT(DATE, GETDATE()) AS SentOn,
              CASE u.Gender
                  WHEN 'F' THEN CEILING(SQRT(u.Age * 2))
                  WHEN 'M' THEN CEILING(POWER(u.Age / 18, 3))
              END AS ChatId,
              u.Id AS UserId
       FROM Users AS u
            JOIN locations AS l ON l.Id = u.LocationId
       WHERE u.Id BETWEEN 10 AND 20;