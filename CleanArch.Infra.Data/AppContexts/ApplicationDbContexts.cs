using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using IdentityServer4.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.AppContexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IIdentityService identityService = null, IMediator mediator = null) : base(options, operationalStoreOptions)
        {
            _identityService = identityService;
            _mediator = mediator;
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTranslation> ProductTranslation { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        public IQueryable<TEntity> ReaderSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>().AsQueryable();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            AddTimeStamp(entities);

            await _mediator.DispatchDomainEventsAsync(entities, cancellationToken).ConfigureAwait(false);

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public void AddTimeStamp(IEnumerable<EntityEntry<EntityBase>> entities)
        {
            string currentUserId = _identityService.UserIdentity;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDt = DateTime.UtcNow;
                    entity.Entity.CreatedBy = currentUserId;
                }
                entity.Entity.UpdatedDt = DateTime.UtcNow;
                entity.Entity.UpdatedBy = currentUserId;
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

