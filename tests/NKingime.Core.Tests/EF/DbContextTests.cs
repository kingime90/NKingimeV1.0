using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NKingime.Core.EF;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using NKingime.Core.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using NKingime.Core.Migrations;

namespace NKingime.Core.Tests.EF
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class DbContextTests
    {
        [Test]
        public void InitializerDatabase()
        {
            var context = new DefaultDbContext();
            IDatabaseInitializer<DefaultDbContext> initializer;
            if (!context.Database.Exists())
            {
                initializer = new CreateDatabaseIfNotExists<DefaultDbContext>();
            }
            else
            {
                initializer = new MigrateDatabaseToLatestVersion<DefaultDbContext, AutoMigrationConfiguration<DefaultDbContext>>();
            }
            Database.SetInitializer(initializer);
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            StorageMappingItemCollection mappingItemCollection = (StorageMappingItemCollection)objectContext.ObjectStateManager
                .MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingItemCollection.GenerateViews(new List<EdmSchemaError>());
            context.Dispose();
        }
    }
}
