SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddOrModifyLanguageSet 
		@languageName nvarchar(100),
		@cultureName nvarchar(100),
		@languageID int output
AS
BEGIN             
	SET NOCOUNT ON;

	select @languageID = [ID] from ent_LanguageSet where lower([Name]) = lower(@languageName)
	if (@languageID is null)
	begin
		insert into ent_LanguageSet ([Name], [CultureName]) values (@languageName, @cultureName)
		select @languageID = SCOPE_IDENTITY()
	end
	else
	begin
		update ent_LanguageSet set [Name] = @languageName, [CultureName] = @cultureName where [ID] = @languageID
	end
END


GO
