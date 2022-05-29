using Common.Utilities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entitiesassembly = typeof(IEntity).Assembly;
            modelBuilder.RegisterAllEntities<IEntity>(entitiesassembly);
            modelBuilder.RegisterEntityTypeConfiguration(entitiesassembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();
        }
    
        public override int SaveChanges()
        {
            _CleanString();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _CleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _CleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _CleanString();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void _CleanString()
        {
            var changedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Modified);
            foreach (var entity in changedEntities)
            {
                if (entity.Entity == null)
                {
                    continue;
                }
                var properties = entity.Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
                foreach (var property in properties)
                {
                    var propname = property.Name;
                    var val = (string)property.GetValue(entity.Entity , null);
                    if (val.Hasvalue())
                    {
                        var newval = "";//val.Fa2En().FixPersianChars();
                        if (newval != val)
                            continue;
                        property.SetValue(entity.Entity, newval, null);
                    }
                }
            }
        }
    }
}
