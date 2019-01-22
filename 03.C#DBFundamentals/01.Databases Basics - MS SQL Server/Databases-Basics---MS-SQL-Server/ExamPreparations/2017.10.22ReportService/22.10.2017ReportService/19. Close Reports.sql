	 CREATE TRIGGER TR_Closing ON Reports AFTER UPDATE
 AS
	DECLARE @statusId INT = (SELECT Id FROM [Status] WHERE Label = 'completed')
	DECLARE @reportId INT = (SELECT Id FROM inserted WHERE CloseDate IS NOT NULL)
		UPDATE Reports 
		SET StatusId = @statusId
		WHERE Id =  (SELECT Id FROM inserted WHERE CloseDate IS NOT NULL)

-- --------------------------------------------------------------------------------

			 CREATE TRIGGER TR_Closing ON Reports AFTER UPDATE
 AS

		UPDATE Reports 
		SET StatusId = (SELECT Id FROM [Status] WHERE Label = 'completed')
		WHERE Id = (SELECT Id FROM inserted WHERE CloseDate IS NOT NULL)