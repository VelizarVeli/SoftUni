CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS
  BEGIN
    DECLARE @SourceOrderId INT = (SELECT o.Id FROM Orders o
                                  WHERE o.Id = @OrderId)

    DECLARE @TargetCancelDate DATE = (SELECT [DateTime] FROM Orders AS o
                                  WHERE [DateTime] = @CancelDate)

    IF (@SourceOrderId IS NULL)
      THROW 50013, 'The order does not exist!', 1

    IF (DATEDIFF(DAY,@TargetCancelDate,@CancelDate) > 3)
      THROW 50013, 'You cannot cancel the order!', 1

	DELETE FROM OrderItems
    WHERE OrderId = @OrderId
    DELETE FROM Orders
    WHERE Id = @OrderId
  END


SELECT [DateTime] FROM Orders AS o
                                  WHERE [DateTime] = '2018-06-01 11:59:06.000'