WITH cte_WrongChatDates(ChatId,
                        ChatStart,
                        FirstMessage)
     AS (
     SELECT c.Id AS ChatId,
            c.StartDate AS ChatStart,
            MIN(m.SentOn) AS FirstMessage
     FROM Chats AS c
          JOIN Messages AS m ON m.ChatId = c.Id
     GROUP BY c.Id,
              c.StartDate
     HAVING c.StartDate > MIN(m.SentOn))

     -- Update the mistaken dates
     UPDATE Chats
       SET
           StartDate =
     (
         SELECT FirstMessage
         FROM cte_WrongChatDates
         WHERE Id = ChatId
     )
     WHERE Id IN
     (
         SELECT ChatId
         FROM cte_WrongChatDates
     );