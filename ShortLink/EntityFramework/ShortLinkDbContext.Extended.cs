using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShortLink.Common.Extensions;
using ShortLink.Common.Helpers;
using ShortLink.EntityFramework.Base;

namespace ShortLink.EntityFramework
{
    public partial class ShortLinkDbContext
    {
        private const string PrimaryKeyName = "Id";
        private const string UniqID = "UniqId";
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.SetQueryFilterOnAllEntities<ISoftDeleted>(p => !p.IsDeleted);
        }
        
        #region Insert
        
        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            PopulateGuidField(entity);
            return base.Add(entity);
        }
        
        public override EntityEntry Add(object entity)
        {
            PopulateGuidField(entity);
            return base.Add(entity);
        }
        
        public override ValueTask<EntityEntry> AddAsync(object entity,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PopulateGuidField(entity);
            return base.AddAsync(entity, cancellationToken);
        }
        
        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity,
            CancellationToken cancellationToken = new CancellationToken())
        {
            PopulateGuidField(entity);
            return base.AddAsync(entity, cancellationToken);
        }
        
        public override void AddRange(IEnumerable<object> entities)
        {
            var enumerable = entities.ToList();
            foreach (object entity in enumerable)
            {
                PopulateGuidField(entity);
            }
        
            base.AddRange(enumerable);
        }
        
        public override void AddRange(params object[] entities)
        {
            foreach (object entity in entities)
            {
                PopulateGuidField(entity);
            }
            base.AddRange(entities);
        }
        
        public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = new CancellationToken())
        {
            var enumerable = entities.ToList();
            foreach (object entity in enumerable)
            {
                PopulateGuidField(entity);
            }
            return base.AddRangeAsync(enumerable, cancellationToken);
        }
        
        public override Task AddRangeAsync(params object[] entities)
        {
            foreach (object entity in entities)
            {
                PopulateGuidField(entity);
            }
            return base.AddRangeAsync(entities);
        }
        
        #endregion
        
        private void PopulateGuidField(object entry)
        {
            PropertyInfo primaryKey = entry.GetType().GetProperties().FirstOrDefault(_ => _.Name == PrimaryKeyName);
            if (primaryKey == null || primaryKey.PropertyType == typeof(int) || primaryKey.PropertyType == typeof(long))
                return;
            
            string guid = Guid.NewGuid().ToString();
            primaryKey.SetValue(entry, guid, null);
            
            // Generate base64String UniqId
            PropertyInfo uniqIdKey = entry.GetType().GetProperties().FirstOrDefault(_ => _.Name == UniqID);
            if (uniqIdKey != null)
            {
                string uniqId = StringHelpers.GenerateUniqId();
                uniqIdKey.SetValue(entry, uniqId, null);
            }
        }
    }
}