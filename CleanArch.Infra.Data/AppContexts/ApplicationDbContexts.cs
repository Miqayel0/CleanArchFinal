using CleanArch.Domain.Entities;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.AppContexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IIdentityService _identityService;
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IIdentityService identityService = null) : base(options, operationalStoreOptions)
        {
            _identityService = identityService;
        }

        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        public IQueryable<TEntity> ReaderSet<TEntity>(bool includeDeleted = false) where TEntity : EntityBase
        {
            if (!includeDeleted)
                return base.Set<TEntity>().Where(x => !x.IsDeleted);
            return base.Set<TEntity>().AsQueryable();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            AddTimestamps(_identityService);
            return await base.SaveChangesAsync(token);
        }

        public override int SaveChanges()
        {
            AddTimestamps(_identityService);
            return base.SaveChanges();
        }

        public int SaveChangesWithoutTimeShtamp()
        {
            return base.SaveChanges();
        }

        private void AddTimestamps(IIdentityService identityService)
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));
            string currentUserId = identityService.UserIdentity;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((EntityBase)entity.Entity).CreatedDt = DateTime.UtcNow;
                    ((EntityBase)entity.Entity).CreatedBy = currentUserId;
                }
                ((EntityBase)entity.Entity).UpdatedDt = DateTime.UtcNow;
                ((EntityBase)entity.Entity).UpdatedBy = currentUserId;
            }
        }
    }
}

