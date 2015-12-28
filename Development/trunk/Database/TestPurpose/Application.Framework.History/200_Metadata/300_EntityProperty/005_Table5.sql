insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind], [ColumnName])
	values (501, 5
		, 'PropertyInt', 0, 1, 'PropertyInt')
insert into met_EntityProperty ([ID], [EntityTypeID]
		, [Name], [Required], [TargetKind]
		, [TargetEntityTypeID], [RelationshipName])
	values (502, 5
		, 'DualTable4s', 1, 4
		, 5, 'rel_Table4_Table5_1')

update met_EntityProperty
	set [OppositeEntityPropertyID] = 502
	where [ID] = 405
update met_EntityProperty
	set [OppositeEntityPropertyID] = 405
	where [ID] = 502

