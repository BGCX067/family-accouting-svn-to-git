insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName])
	values (101, 1
		, 'PropertyInt', 1, 1, 'PropertyInt')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName])
	values (102, 1
		, 'PropertyString', 0, 1, 'PropertyString')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName])
	values (103, 1
		, 'PropertyDatetime', 0, 1, 'PropertyDatetime')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind]
		, [TargetEntityTypeID], [RelationshipName])
	values (104, 1
		, 'DualTable4s', 1, 4
		, 4, 'ent_Table1_ent_Table4_FK1')

