SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddOrModifyResourceItem 
		@languageID int, 
		@keyName nvarchar(200),
		@content nvarchar(2000)
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @keyID int
	select @keyID = [ID] from met_ResourceKey where [Name] = @keyName
	if (@keyID is null)
	begin
		insert into met_ResourceKey ([Name]) values (@keyName)
		select @keyID = scope_identity()
	end

	if (exists (select * from ent_ResourceContent where ([LanguageSetID] = @languageID) and ([ResourceKeyID] = @keyID)))
	begin
		update ent_ResourceContent set [Content] = @content where ([LanguageSetID] = @languageID) and ([ResourceKeyID] = @keyID)
	end
	else
	begin
		insert into ent_ResourceContent ([LanguageSetID], [ResourceKeyID] ,[Content]) values (@languageID ,@keyID ,@content)
	end
END




GO
