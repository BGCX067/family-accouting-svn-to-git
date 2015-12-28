SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER tri_UpdateEntityHistoryRepresentation 
   ON rec_CoreHistory 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	declare @actionType tinyint
	SELECT @actionType = hist.ActionType FROM inserted hist
	if (@actionType = 1)
	begin
		INSERT INTO ast_EntityHistoryRepresentation
			(EntityTypeID, EntityID
			, CreatorID, CreatorName, CreationTimeStamp, CreationHistoryID
			, LastToucherID, LastToucherName, LastTouchTimeStamp, LastTouchHistoryID)
			SELECT hist.EntityTypeID, hist.EntityID
					, u.ID, u.Name, hist.TimeStamp, hist.ID
					, u.ID, u.Name, hist.TimeStamp, hist.ID
				FROM inserted hist
					INNER JOIN rec_ApplicationTransaction at ON hist.ApplicationTransactionID = at.ID
					LEFT OUTER JOIN ent_User u ON at.UserID = u.ID
	end
	else
	begin
		UPDATE ast_EntityHistoryRepresentation
			SET LatestModifierID = u.ID
				, LatestModifierName = u.Name
				, LatestModificationTimeStamp = hist.TimeStamp
				, LatestModificationHistoryID = hist.ID
				, LastToucherID = u.ID
				, LastToucherName = u.Name
				, LastTouchTimeStamp = hist.TimeStamp
				, LastTouchHistoryID = hist.ID
			FROM inserted hist
					INNER JOIN rec_ApplicationTransaction at ON hist.ApplicationTransactionID = at.ID
					LEFT OUTER JOIN ent_User u ON at.UserID = u.ID
			WHERE (ast_EntityHistoryRepresentation.EntityTypeID = hist.EntityTypeID)
				AND (ast_EntityHistoryRepresentation.EntityID = hist.EntityID)
	end
	
END
GO
