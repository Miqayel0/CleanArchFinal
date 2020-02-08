﻿using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.ProductAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Permission> Permissions { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductTranslation> ProductTranslation { get; set; }
        DbSet<Language> Languages { get; set; }

        DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase;
        IQueryable<TEntity> ReaderSet<TEntity>(bool includeDeleted = false) where TEntity : EntityBase;
        Task<int> SaveChangesAsync(CancellationToken token = default);
        int SaveChanges();
        int SaveChangesWithoutTimeShtamp();
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
    }
}