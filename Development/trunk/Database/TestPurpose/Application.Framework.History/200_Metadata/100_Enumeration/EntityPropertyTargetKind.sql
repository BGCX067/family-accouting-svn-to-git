INSERT INTO met_EnumerationType ([ID], [FullTypeName], [AssemblyName], [IsFlag])
     VALUES (1
		, 'Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata.EntityPropertyTargetKind'
		, 'Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata'
		, 0)

INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (1001, 1, 1, 'NormalScalar')
INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (1002, 1, 2, 'Enumeration')
INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (1003, 1, 3, 'SingleRelated')
INSERT INTO met_EnumerationItem ([ID], [EnumerationTypeID], [Value], [Name])
     VALUES (1004, 1, 4, 'List')