INSERT INTO met_EnumerationType ([ID], [FullTypeName], [AssemblyName], [IsFlag])
     VALUES (11
		, 'Wang.Velika.FamilyAccounting.Application.Framework.History.HistoryActionType'
		, 'Wang.Velika.FamilyAccounting.Application.Framework.History'
		, 0)

INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (11001, 11, 1, 'Create')
INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (11002, 11, 2, 'Modify')
INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (11003, 11, 3, 'Delete')