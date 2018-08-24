﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Globalization;
using System.Linq;



namespace CrossCutting.Mietmaschinendatenbank_DataClasses
{
    public partial class MietmaschinendatenbankModelContainer : ObjectContext
    {
        public const string ConnectionString = "name=MietmaschinendatenbankModelContainer";
        public const string ContainerName = "MietmaschinendatenbankModelContainer";
    
        #region Constructors
    
        public MietmaschinendatenbankModelContainer()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public MietmaschinendatenbankModelContainer(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public MietmaschinendatenbankModelContainer(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }

        #endregion

        #region ObjectSet Properties
    
        public ObjectSet<Maschinenkauf> MaschinenkauflisteSatz
        {
            get { return _maschinenkauflisteSatz  ?? (_maschinenkauflisteSatz = CreateObjectSet<Maschinenkauf>("MaschinenkauflisteSatz")); }
        }
        private ObjectSet<Maschinenkauf> _maschinenkauflisteSatz;
    
        public ObjectSet<Kunde> KundenlisteSatz
        {
            get { return _kundenlisteSatz  ?? (_kundenlisteSatz = CreateObjectSet<Kunde>("KundenlisteSatz")); }
        }
        private ObjectSet<Kunde> _kundenlisteSatz;
    
        public ObjectSet<Vermietung> VermietungslisteSatz
        {
            get { return _vermietungslisteSatz  ?? (_vermietungslisteSatz = CreateObjectSet<Vermietung>("VermietungslisteSatz")); }
        }
        private ObjectSet<Vermietung> _vermietungslisteSatz;
    
        public ObjectSet<Maschinenart> MaschinenartenlisteSatz
        {
            get { return _maschinenartenlisteSatz  ?? (_maschinenartenlisteSatz = CreateObjectSet<Maschinenart>("MaschinenartenlisteSatz")); }
        }
        private ObjectSet<Maschinenart> _maschinenartenlisteSatz;
    
        public ObjectSet<Lagerbestand> LagerbestandSatz
        {
            get { return _lagerbestandSatz  ?? (_lagerbestandSatz = CreateObjectSet<Lagerbestand>("LagerbestandSatz")); }
        }
        private ObjectSet<Lagerbestand> _lagerbestandSatz;

        #endregion

    }
}
