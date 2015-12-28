﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("Wang.Velika.FamilyAccounting.Application.Framework.History", "rec_CoreHistory_rec_CollectionChange_FK1", "CoreHistory", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Wang.Velika.FamilyAccounting.Application.Framework.History.CoreHistory), "rec_CollectionChange", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Wang.Velika.FamilyAccounting.Application.Framework.History.CollectionChange))]

// Original file name:
// Generation date: 2009-9-25 17:03:44
namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    
    /// <summary>
    /// There are no comments for HistoryContext in the schema.
    /// </summary>
    public partial class HistoryContext : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new HistoryContext object using the connection string found in the 'HistoryContext' section of the application configuration file.
        /// </summary>
        public HistoryContext() : 
                base("name=HistoryContext", "HistoryContext")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new HistoryContext object.
        /// </summary>
        public HistoryContext(string connectionString) : 
                base(connectionString, "HistoryContext")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new HistoryContext object.
        /// </summary>
        public HistoryContext(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "HistoryContext")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for ApplicationTransactionSet in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<ApplicationTransaction> ApplicationTransactionSet
        {
            get
            {
                if ((this._ApplicationTransactionSet == null))
                {
                    this._ApplicationTransactionSet = base.CreateQuery<ApplicationTransaction>("[ApplicationTransactionSet]");
                }
                return this._ApplicationTransactionSet;
            }
        }
        private global::System.Data.Objects.ObjectQuery<ApplicationTransaction> _ApplicationTransactionSet;
        /// <summary>
        /// There are no comments for CoreHistorySet in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<CoreHistory> CoreHistorySet
        {
            get
            {
                if ((this._CoreHistorySet == null))
                {
                    this._CoreHistorySet = base.CreateQuery<CoreHistory>("[CoreHistorySet]");
                }
                return this._CoreHistorySet;
            }
        }
        private global::System.Data.Objects.ObjectQuery<CoreHistory> _CoreHistorySet;
        /// <summary>
        /// There are no comments for CollectionChangeSet in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<CollectionChange> CollectionChangeSet
        {
            get
            {
                if ((this._CollectionChangeSet == null))
                {
                    this._CollectionChangeSet = base.CreateQuery<CollectionChange>("[CollectionChangeSet]");
                }
                return this._CollectionChangeSet;
            }
        }
        private global::System.Data.Objects.ObjectQuery<CollectionChange> _CollectionChangeSet;
        /// <summary>
        /// There are no comments for ApplicationTransactionSet in the schema.
        /// </summary>
        public void AddToApplicationTransactionSet(ApplicationTransaction applicationTransaction)
        {
            base.AddObject("ApplicationTransactionSet", applicationTransaction);
        }
        /// <summary>
        /// There are no comments for CoreHistorySet in the schema.
        /// </summary>
        public void AddToCoreHistorySet(CoreHistory coreHistory)
        {
            base.AddObject("CoreHistorySet", coreHistory);
        }
        /// <summary>
        /// There are no comments for CollectionChangeSet in the schema.
        /// </summary>
        public void AddToCollectionChangeSet(CollectionChange collectionChange)
        {
            base.AddObject("CollectionChangeSet", collectionChange);
        }
    }
    /// <summary>
    /// There are no comments for Wang.Velika.FamilyAccounting.Application.Framework.History.ApplicationTransaction in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ID
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="Wang.Velika.FamilyAccounting.Application.Framework.History", Name="ApplicationTransaction")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ApplicationTransaction : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ApplicationTransaction object.
        /// </summary>
        /// <param name="id">Initial value of ID.</param>
        public static ApplicationTransaction CreateApplicationTransaction(int id)
        {
            ApplicationTransaction applicationTransaction = new ApplicationTransaction();
            applicationTransaction.ID = id;
            return applicationTransaction;
        }
        /// <summary>
        /// There are no comments for Property ID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this.OnIDChanging(value);
                this.ReportPropertyChanging("ID");
                this._ID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID");
                this.OnIDChanged();
            }
        }
        private int _ID;
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        /// <summary>
        /// There are no comments for Property ExternalID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string ExternalID
        {
            get
            {
                return this._ExternalID;
            }
            set
            {
                this.OnExternalIDChanging(value);
                this.ReportPropertyChanging("ExternalID");
                this._ExternalID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ExternalID");
                this.OnExternalIDChanged();
            }
        }
        private string _ExternalID;
        partial void OnExternalIDChanging(string value);
        partial void OnExternalIDChanged();
        /// <summary>
        /// There are no comments for Property UserID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this.OnUserIDChanging(value);
                this.ReportPropertyChanging("UserID");
                this._UserID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("UserID");
                this.OnUserIDChanged();
            }
        }
        private global::System.Nullable<int> _UserID;
        partial void OnUserIDChanging(global::System.Nullable<int> value);
        partial void OnUserIDChanged();
        /// <summary>
        /// There are no comments for Property RemoteEndPoint in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string RemoteEndPoint
        {
            get
            {
                return this._RemoteEndPoint;
            }
            set
            {
                this.OnRemoteEndPointChanging(value);
                this.ReportPropertyChanging("RemoteEndPoint");
                this._RemoteEndPoint = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("RemoteEndPoint");
                this.OnRemoteEndPointChanged();
            }
        }
        private string _RemoteEndPoint;
        partial void OnRemoteEndPointChanging(string value);
        partial void OnRemoteEndPointChanged();
        /// <summary>
        /// There are no comments for Property LocalEndPoint in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string LocalEndPoint
        {
            get
            {
                return this._LocalEndPoint;
            }
            set
            {
                this.OnLocalEndPointChanging(value);
                this.ReportPropertyChanging("LocalEndPoint");
                this._LocalEndPoint = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("LocalEndPoint");
                this.OnLocalEndPointChanged();
            }
        }
        private string _LocalEndPoint;
        partial void OnLocalEndPointChanging(string value);
        partial void OnLocalEndPointChanged();
        /// <summary>
        /// There are no comments for Property Action in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Action
        {
            get
            {
                return this._Action;
            }
            set
            {
                this.OnActionChanging(value);
                this.ReportPropertyChanging("Action");
                this._Action = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Action");
                this.OnActionChanged();
            }
        }
        private string _Action;
        partial void OnActionChanging(string value);
        partial void OnActionChanged();
        /// <summary>
        /// There are no comments for Property BeginTimestamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> BeginTimestamp
        {
            get
            {
                return this._BeginTimestamp;
            }
            set
            {
                this.OnBeginTimestampChanging(value);
                this.ReportPropertyChanging("BeginTimestamp");
                this._BeginTimestamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("BeginTimestamp");
                this.OnBeginTimestampChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _BeginTimestamp;
        partial void OnBeginTimestampChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnBeginTimestampChanged();
        /// <summary>
        /// There are no comments for Property EndTimestamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> EndTimestamp
        {
            get
            {
                return this._EndTimestamp;
            }
            set
            {
                this.OnEndTimestampChanging(value);
                this.ReportPropertyChanging("EndTimestamp");
                this._EndTimestamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("EndTimestamp");
                this.OnEndTimestampChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _EndTimestamp;
        partial void OnEndTimestampChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnEndTimestampChanged();
        /// <summary>
        /// There are no comments for Property RoleID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                this.OnRoleIDChanging(value);
                this.ReportPropertyChanging("RoleID");
                this._RoleID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("RoleID");
                this.OnRoleIDChanged();
            }
        }
        private global::System.Nullable<int> _RoleID;
        partial void OnRoleIDChanging(global::System.Nullable<int> value);
        partial void OnRoleIDChanged();
    }
    /// <summary>
    /// There are no comments for Wang.Velika.FamilyAccounting.Application.Framework.History.CoreHistory in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ID
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="Wang.Velika.FamilyAccounting.Application.Framework.History", Name="CoreHistory")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class CoreHistory : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new CoreHistory object.
        /// </summary>
        /// <param name="id">Initial value of ID.</param>
        /// <param name="entityTypeID">Initial value of EntityTypeID.</param>
        /// <param name="entityID">Initial value of EntityID.</param>
        /// <param name="timestamp">Initial value of Timestamp.</param>
        /// <param name="applicationTransactionID">Initial value of ApplicationTransactionID.</param>
        public static CoreHistory CreateCoreHistory(int id, int entityTypeID, int entityID, global::System.DateTime timestamp, int applicationTransactionID)
        {
            CoreHistory coreHistory = new CoreHistory();
            coreHistory.ID = id;
            coreHistory.EntityTypeID = entityTypeID;
            coreHistory.EntityID = entityID;
            coreHistory.Timestamp = timestamp;
            coreHistory.ApplicationTransactionID = applicationTransactionID;
            return coreHistory;
        }
        /// <summary>
        /// There are no comments for Property ID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this.OnIDChanging(value);
                this.ReportPropertyChanging("ID");
                this._ID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID");
                this.OnIDChanged();
            }
        }
        private int _ID;
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        /// <summary>
        /// There are no comments for Property EntityTypeID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int EntityTypeID
        {
            get
            {
                return this._EntityTypeID;
            }
            set
            {
                this.OnEntityTypeIDChanging(value);
                this.ReportPropertyChanging("EntityTypeID");
                this._EntityTypeID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("EntityTypeID");
                this.OnEntityTypeIDChanged();
            }
        }
        private int _EntityTypeID;
        partial void OnEntityTypeIDChanging(int value);
        partial void OnEntityTypeIDChanged();
        /// <summary>
        /// There are no comments for Property ActionTypeRaw in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        private byte ActionTypeRaw
        {
            get
            {
                return this._ActionTypeRaw;
            }
            set
            {
                this.OnActionTypeRawChanging(value);
                this.ReportPropertyChanging("ActionTypeRaw");
                this._ActionTypeRaw = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ActionTypeRaw");
                this.OnActionTypeRawChanged();
            }
        }
        private byte _ActionTypeRaw;
        partial void OnActionTypeRawChanging(byte value);
        partial void OnActionTypeRawChanged();
        /// <summary>
        /// There are no comments for Property EntityID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int EntityID
        {
            get
            {
                return this._EntityID;
            }
            set
            {
                this.OnEntityIDChanging(value);
                this.ReportPropertyChanging("EntityID");
                this._EntityID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("EntityID");
                this.OnEntityIDChanged();
            }
        }
        private int _EntityID;
        partial void OnEntityIDChanging(int value);
        partial void OnEntityIDChanged();
        /// <summary>
        /// There are no comments for Property Timestamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.DateTime Timestamp
        {
            get
            {
                return this._Timestamp;
            }
            set
            {
                this.OnTimestampChanging(value);
                this.ReportPropertyChanging("Timestamp");
                this._Timestamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Timestamp");
                this.OnTimestampChanged();
            }
        }
        private global::System.DateTime _Timestamp;
        partial void OnTimestampChanging(global::System.DateTime value);
        partial void OnTimestampChanged();
        /// <summary>
        /// There are no comments for Property ApplicationTransactionID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int ApplicationTransactionID
        {
            get
            {
                return this._ApplicationTransactionID;
            }
            set
            {
                this.OnApplicationTransactionIDChanging(value);
                this.ReportPropertyChanging("ApplicationTransactionID");
                this._ApplicationTransactionID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ApplicationTransactionID");
                this.OnApplicationTransactionIDChanged();
            }
        }
        private int _ApplicationTransactionID;
        partial void OnApplicationTransactionIDChanging(int value);
        partial void OnApplicationTransactionIDChanged();
        /// <summary>
        /// There are no comments for Property Comment in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this.OnCommentChanging(value);
                this.ReportPropertyChanging("Comment");
                this._Comment = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("Comment");
                this.OnCommentChanged();
            }
        }
        private string _Comment;
        partial void OnCommentChanging(string value);
        partial void OnCommentChanged();
        /// <summary>
        /// There are no comments for CollectionChanges in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("Wang.Velika.FamilyAccounting.Application.Framework.History", "rec_CoreHistory_rec_CollectionChange_FK1", "rec_CollectionChange")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<CollectionChange> CollectionChanges
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<CollectionChange>("Wang.Velika.FamilyAccounting.Application.Framework.History.rec_CoreHistory_rec_Co" +
                        "llectionChange_FK1", "rec_CollectionChange");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<CollectionChange>("Wang.Velika.FamilyAccounting.Application.Framework.History.rec_CoreHistory_rec_Co" +
                            "llectionChange_FK1", "rec_CollectionChange", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for Wang.Velika.FamilyAccounting.Application.Framework.History.CollectionChange in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ID
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="Wang.Velika.FamilyAccounting.Application.Framework.History", Name="CollectionChange")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class CollectionChange : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new CollectionChange object.
        /// </summary>
        /// <param name="id">Initial value of ID.</param>
        /// <param name="entityPropertyID">Initial value of EntityPropertyID.</param>
        public static CollectionChange CreateCollectionChange(int id, int entityPropertyID)
        {
            CollectionChange collectionChange = new CollectionChange();
            collectionChange.ID = id;
            collectionChange.EntityPropertyID = entityPropertyID;
            return collectionChange;
        }
        /// <summary>
        /// There are no comments for Property ID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this.OnIDChanging(value);
                this.ReportPropertyChanging("ID");
                this._ID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID");
                this.OnIDChanged();
            }
        }
        private int _ID;
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        /// <summary>
        /// There are no comments for Property EntityPropertyID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int EntityPropertyID
        {
            get
            {
                return this._EntityPropertyID;
            }
            set
            {
                this.OnEntityPropertyIDChanging(value);
                this.ReportPropertyChanging("EntityPropertyID");
                this._EntityPropertyID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("EntityPropertyID");
                this.OnEntityPropertyIDChanged();
            }
        }
        private int _EntityPropertyID;
        partial void OnEntityPropertyIDChanging(int value);
        partial void OnEntityPropertyIDChanged();
        /// <summary>
        /// There are no comments for Property ExtraSourceEntityID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> ExtraSourceEntityID
        {
            get
            {
                return this._ExtraSourceEntityID;
            }
            set
            {
                this.OnExtraSourceEntityIDChanging(value);
                this.ReportPropertyChanging("ExtraSourceEntityID");
                this._ExtraSourceEntityID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ExtraSourceEntityID");
                this.OnExtraSourceEntityIDChanged();
            }
        }
        private global::System.Nullable<int> _ExtraSourceEntityID;
        partial void OnExtraSourceEntityIDChanging(global::System.Nullable<int> value);
        partial void OnExtraSourceEntityIDChanged();
        /// <summary>
        /// There are no comments for Property EstablishedEntityID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> EstablishedEntityID
        {
            get
            {
                return this._EstablishedEntityID;
            }
            set
            {
                this.OnEstablishedEntityIDChanging(value);
                this.ReportPropertyChanging("EstablishedEntityID");
                this._EstablishedEntityID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("EstablishedEntityID");
                this.OnEstablishedEntityIDChanged();
            }
        }
        private global::System.Nullable<int> _EstablishedEntityID;
        partial void OnEstablishedEntityIDChanging(global::System.Nullable<int> value);
        partial void OnEstablishedEntityIDChanged();
        /// <summary>
        /// There are no comments for Property ReleasedEntityID in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> ReleasedEntityID
        {
            get
            {
                return this._ReleasedEntityID;
            }
            set
            {
                this.OnReleasedEntityIDChanging(value);
                this.ReportPropertyChanging("ReleasedEntityID");
                this._ReleasedEntityID = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ReleasedEntityID");
                this.OnReleasedEntityIDChanged();
            }
        }
        private global::System.Nullable<int> _ReleasedEntityID;
        partial void OnReleasedEntityIDChanging(global::System.Nullable<int> value);
        partial void OnReleasedEntityIDChanged();
        /// <summary>
        /// There are no comments for MainHistory in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("Wang.Velika.FamilyAccounting.Application.Framework.History", "rec_CoreHistory_rec_CollectionChange_FK1", "CoreHistory")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public CoreHistory MainHistory
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<CoreHistory>("Wang.Velika.FamilyAccounting.Application.Framework.History.rec_CoreHistory_rec_Co" +
                        "llectionChange_FK1", "CoreHistory").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<CoreHistory>("Wang.Velika.FamilyAccounting.Application.Framework.History.rec_CoreHistory_rec_Co" +
                        "llectionChange_FK1", "CoreHistory").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for MainHistory in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<CoreHistory> MainHistoryReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<CoreHistory>("Wang.Velika.FamilyAccounting.Application.Framework.History.rec_CoreHistory_rec_Co" +
                        "llectionChange_FK1", "CoreHistory");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<CoreHistory>("Wang.Velika.FamilyAccounting.Application.Framework.History.rec_CoreHistory_rec_Co" +
                            "llectionChange_FK1", "CoreHistory", value);
                }
            }
        }
    }
}