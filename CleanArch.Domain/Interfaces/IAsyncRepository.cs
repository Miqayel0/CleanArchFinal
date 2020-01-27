using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IAsyncRepository : IDisposable
    {
        Task<IEnumerable<T>> GetAllAsync<T>(bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<IEnumerable<T>> GetAllAsNoTrackingAsync<T>(bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<IEnumerable<T>> GetByPagingAsNoTrackingAsync<T>(bool includeDeleted = false, int page = 1, int pageSize = 10, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<T> GetByIdAsync<T>(long id, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<T> GetByIdAsNoTrackingAsync<T>(long id, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<IEnumerable<T>> FilterAsNoTrackingAsync<T>(Expression<Func<T, bool>> query, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<IEnumerable<T>> FilterAsync<T>(Expression<Func<T, bool>> query, bool includeDeleted = false, params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;
        Task<IEnumerable<T>> FilterWithQueryAsync<T>(Expression<Func<T, bool>> query, Func<IQueryable<T>, IQueryable<T>> includeMembers, bool includeDeleted = false) where T : EntityBase;
        Task<T> GetAndCheckWithAssignerWithQueryAsync<T>(long entityId, string assignerId, Func<IQueryable<T>, IQueryable<T>> includeMembers, bool includeDeleted = false) where T : EntityBase;

        IQueryable<T> Filter<T>(Expression<Func<T, bool>> query, bool includeDeleted = false,
            params Expression<Func<T, object>>[] includeExpression) where T : EntityBase;

        Task<T> Create<T>(T entity) where T : EntityBase;
        Task<bool> Remove<T>(long id) where T : EntityBase;
        Task<bool> RemoveRange<T>(IList<long> ids) where T : EntityBase;
        Task<bool> HardRemove<T>(long id) where T : EntityBase;
        Task<bool> HardRemoveRange<T>(IList<long> ids, bool includeDeleted = false) where T : EntityBase;
        Task<bool> Update<T>(T entity) where T : EntityBase;
        Task<bool> UpdateRange<T>(IEnumerable<T> entities) where T : EntityBase;
        Task<bool> CreateRange<T>(IList<T> entities) where T : EntityBase;

        Task CompleteAsync(CancellationToken cancellationToken = default);
        void Complete();

    }
}
