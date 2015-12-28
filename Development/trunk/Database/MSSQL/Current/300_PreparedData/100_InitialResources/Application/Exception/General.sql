declare @languageID int
exec cspd_AddOrModifyLanguageSet	'English(United States)', 'en-us', @languageID OUTPUT

exec cspd_AddOrModifyResourceItem @languageID, 'Application.Exception.General.ArgumentNull', 'Passed-in argument "{0}" can not be null.'