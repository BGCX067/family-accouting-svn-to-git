insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName])
	values (401, 4
		, 'PropertyString', 0, 1, 'PropertyString')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName]
		, [TargetEntityTypeID], [RelationshipName])
	values (402, 4
		, 'DualTable1', 1, 3, 'Table1ID'
		, 1 , 'ent_Table1_ent_Table4_FK1')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName]
		, [TargetEntityTypeID], [RelationshipName])
	values (403, 4
		, 'MonoTable2', 0, 3, 'Table2ID'
		, 2, 'ent_Table2_ent_Table4_FK1')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName]
		, [TargetEntityTypeID], [RelationshipName])
	values (404, 4
		, 'MetaTable3', 1, 3, 'Table3ID'
		, 503, 'met_Table3_ent_Table4_FK1')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind]
		, [TargetEntityTypeID], [RelationshipName])
	values (405, 4
		, 'DualTable5s', 1, 4
		, 5, 'rel_Table4_Table5_1')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind]
		, [TargetEntityTypeID], [RelationshipName])
	values (406, 4
		, 'MonoTable5s', 1, 4
		, 5, 'rel_Table4_Table5_2')

update met_EntityProperty
	set [OppositeEntityPropertyID] = 402
	where [ID] = 104
update met_EntityProperty
	set [OppositeEntityPropertyID] = 104
	where [ID] = 402

