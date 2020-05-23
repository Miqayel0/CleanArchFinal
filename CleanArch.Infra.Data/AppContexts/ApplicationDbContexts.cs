using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using IdentityServer4.EntityFramework.Options;
using MediatR;
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

        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            var entities = ChangeTracker.Entries<EntityBase>();
            string currentUserId = _identityService.UserIdentity;

            foreach (var entity in entities.Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDt = DateTime.UtcNow;
                    entity.Entity.CreatedBy = currentUserId;
                }
                entity.Entity.UpdatedDt = DateTime.UtcNow;
                entity.Entity.UpdatedBy = currentUserId;
            }

            int result = await base.SaveChangesAsync(token).ConfigureAwait(false);

            var entitiesWithEvents = entities
            .Where(e => e.Entity.Events.Any())
            .Select(e => e.Entity)
            .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();

                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public int SaveChangesWithoutTimeShtamp()
        {
            return base.SaveChanges();
        }
    }
}

