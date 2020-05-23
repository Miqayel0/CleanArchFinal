using CleanArch.Domain.Entities;
using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class AsyncRepository : IRepository
    {
        private readonly IApplicationDbContext _context;
        public AsyncRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Async Read Part

        public async Task<IEnumerable<T>> GetAllAsync<T>(bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted);
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return await set.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsNoTrackingAsync<T>(bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, include) => current.Include(include));
            return await set.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByPagingAsNoTrackingAsync<T>(bool includeDeleted = false, int page = 1, int pageSize = 10,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Skip(page * pageSize).Take(pageSize).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, include) => current.Include(include));
            return await set.ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(long id, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Where(x => x.Id == id);
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return await set.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsNoTrackingAsync<T>(long id, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Where(x => x.Id == id).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return await set.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FilterAsNoTrackingAsync<T>(Expression<Func<T, bool>> query, bool includeDeleted = false,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            if (query == null)
                throw new SmartException("Query is null");
            var set = _context.ReaderSet<T>(includeDeleted).Where(query).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return await set.ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync<T>(Expression<Func<T, bool>> query, bool includeDeleted = false,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            if (query == null)
                throw new SmartException("Query is null");
            var set = _context.ReaderSet<T>(includeDeleted).Where(query);
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return await set.ToListAsync();
        }


        public async Task<IEnumerable<T>> FilterWithQueryAsync<T>(Expression<Func<T, bool>> query,
            Func<IQueryable<T>, IQueryable<T>> includeMembers, bool includeDeleted = false) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Where(query);
            var result = includeMembers(set);
            return await result.ToListAsync();
        }

        public async Task<T> GetAndCheckWithAssignerWithQueryAsync<T>(long entityId, string assignerId, Func<IQueryable<T>, IQueryable<T>> includeMembers, bool includeDeleted = false) where T : EntityBase
        {
            var set = _context.ReaderSet<T>().Where(c => c.Id == entityId && c.CreatedBy == assignerId);
            var result = includeMembers(set);
            return await result.FirstOrDefaultAsync() ?? throw new SmartException("You can not modify this entity because don't have suitable permissions!");
        }

        #endregion

        #region Sync Read Part

        public IQueryable<T> GetAll<T>(bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted);
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return set;
        }

        public IQueryable<T> GetAllAsNoTracking<T>(bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return set;
        }

        public IQueryable<T> GetByPagingAsNoTracking<T>(int page = 1, int pageSize = 10, bool includeDeleted = false,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Skip(page * pageSize).Take(pageSize)
                .AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, include) => current.Include(include));
            return set;
        }

        public T GetById<T>(long id, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Where(entity => entity.Id == id);
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return set.FirstOrDefault();
        }

        public T GetByIdAsNoTracking<T>(long id, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Where(entity => entity.Id == id).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return set.FirstOrDefault();
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> query, bool includeDeleted = false,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            if (query == null)
                throw new SmartException("Query is null");
            var set = _context.ReaderSet<T>(includeDeleted).Where(query);
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return set;
        }

        public IQueryable<T> FilterAsNoTracking<T>(Expression<Func<T, bool>> query, bool includeDeleted = false,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase
        {
            if (query == null)
                throw new SmartException("Query is null");
            var set = _context.ReaderSet<T>(includeDeleted).Where(query).AsNoTracking();
            if (includeExpression.Any())
                set = includeExpression.Aggregate(set, (current, variable) => current.Include(variable));
            return set;
        }

        public IQueryable<T> FilterWithQuery<T>(Expression<Func<T, bool>> query,
            Func<IQueryable<T>, IQueryable<T>> includeMembers, bool includeDeleted = false) where T : EntityBase
        {
            var set = _context.ReaderSet<T>(includeDeleted).Where(query);
            var result = includeMembers(set);
            return result;
        }

        #endregion


        #region CUD Part

        public async Task<T> Create<T>(T entity) where T : EntityBase
        {
            await _context.WriterSet<T>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> CreateRange<T>(IList<T> entity) where T : EntityBase
        {
            try
            {
                await _context.WriterSet<T>().AddRangeAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Remove<T>(long id) where T : EntityBase
        {
            try
            {
                var entityToRemove = await GetByIdAsync<T>(id);
                if (entityToRemove == null)
                    return false;
                entityToRemove.IsDeleted = true;
                _context.WriterSet<T>().Update(entityToRemove);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> HardRemove<T>(long id) where T : EntityBase
        {
            try
            {
                var entityToRemove = await GetByIdAsync<T>(id);
                _context.WriterSet<T>().Remove(entityToRemove);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveRange<T>(IList<long> ids) where T : EntityBase
        {
            try
            {
                var entityToRemove = await Filter<T>(x => ids.Contains(x.Id)).ToListAsync();
                foreach (var variable in entityToRemove)
                {
                    if (variable == null)
                        continue;
                    variable.IsDeleted = true;
                }
                _context.WriterSet<T>().UpdateRange(entityToRemove);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> HardRemoveRange<T>(IList<long> ids, bool includeDeleted = false) where T : EntityBase
        {
            try
            {
                var entityToRemove = await Filter<T>(x => ids.Contains(x.Id), includeDeleted).ToListAsync();
                _context.WriterSet<T>().RemoveRange(entityToRemove);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Update<T>(T entity) where T : EntityBase
        {
            try
            {
                await Task.FromResult(_context.WriterSet<T>().Update(entity));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateRange<T>(IEnumerable<T> entities) where T : EntityBase
        {
            try
            {
                await Task.Run(() => _context.WriterSet<T>().UpdateRange(entities));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        #endregion

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public IApplicationDbContext GetContext()
        {
            return _context;
        }
    }
}
