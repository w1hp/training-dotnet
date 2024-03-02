using Cvl.Training.SmsEmailSender.Core.Base;
using Cvl.Training.SmsEmailSender.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvl.Training.SmsEmailSender.Infrastructure.Database
{
    internal class SmsEmailDbContext : DbContext, IWriteEntities, ITransientWriterEntities
    {
        private readonly string? _connectionString;

        public DbSet<Sms> Sms { get; set; } = null!;
        public DbSet<Email> Email { get; set; } = null!;
        public SmsEmailDbContext(DbContextOptions<SmsEmailDbContext> options) : base(options)
        {
        }
        public SmsEmailDbContext() : base()
        {
        }

        public SmsEmailDbContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
            else
            {
                base.OnConfiguring(optionsBuilder);
            }
        }


        public IQueryable<TEntity> QueryReadOnly<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>().AsNoTracking().Where(x => x.Archival == false); // detach results from context
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>().Where(x => x.Archival == false);
        }

        public async Task<TEntity?> Find<TEntity>(long id) where TEntity : BaseEntity
        {
            return await Set<TEntity>().FindAsync(id);
        }

        async Task IWriteEntities.Add<TEntity>(TEntity entity) where TEntity : class
        {
            await Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var obj = await Set<TEntity>().FindAsync(entity.Id) ?? throw new Exception($"Object {typeof(TEntity).Name} with id={entity.Id} not found");
            obj.Archival = true;
            await SaveChangesAsync();
        }

        void IWriteEntities.MarkAsUpdated<TEntity>(TEntity entity) where TEntity : class
        {
            base.Attach(entity);
            base.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State is EntityState.Added or EntityState.Modified);

            foreach (EntityEntry entityEntry in entries)
            {
                if (entityEntry?.Entity is not BaseEntity entry)
                    continue;

                entry.ModifiedDate = DateTime.Now.ToUniversalTime();
                entry.SimpleSearchIndex = entry.ToString();
                if (entityEntry.State == EntityState.Added)
                {
                    entry.CreatedDate = DateTime.Now.ToUniversalTime();
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
