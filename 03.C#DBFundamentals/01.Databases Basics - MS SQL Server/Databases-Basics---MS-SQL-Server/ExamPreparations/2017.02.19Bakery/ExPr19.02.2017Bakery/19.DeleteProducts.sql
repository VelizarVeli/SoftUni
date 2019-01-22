CREATE TRIGGER tr_DeleteProduct ON products
INSTEAD OF DELETE
AS
     BEGIN
         DECLARE @productId INT= (SELECT Id FROM deleted);

	    -- Delete Feedbacks
         DELETE FROM Feedbacks
         WHERE ProductId = @productId;

	    -- Delete ProductIngredient relations
         DELETE FROM ProductsIngredients
         WHERE ProductId = @productId;

	    -- Delete Product
         DELETE FROM Products
         WHERE Id = @productId;
     END;
	 