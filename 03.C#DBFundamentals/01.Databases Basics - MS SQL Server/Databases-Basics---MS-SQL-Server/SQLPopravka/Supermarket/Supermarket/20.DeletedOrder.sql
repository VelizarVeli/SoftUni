CREATE TRIGGER T_DeletedOrder ON OrderItems
    AFTER DELETE
  AS
    BEGIN
	INSERT INTO DeletedOrders
	 (OrderId, ItemId , ItemQuantity)
    SELECT
        OrderId  , ItemId, Quantity 
        FROM deleted
    END