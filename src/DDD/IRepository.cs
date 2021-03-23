using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace UltraNuke.CommonMormon.DDD
{
    /// <summary>
    /// IRepository提供应用程序仓储模式基本操作的接口
    /// </summary>
    public interface IRepository
    {
        #region Methods
        void Entry<T>(T t) where T : AggregateRoot;
        void Save();
        T Get<T>(Guid id, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot;
        T Get<T>(Expression<Func<T, bool>> where, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> filter=null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy=null, Func<IQueryable<T>, IQueryable<T>> includes=null) where T : AggregateRoot;
        IQueryable<T> QueryByPage<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot;
        void BeginTransaction();
        void Commit();
        void Rollback();

        Task SaveAsync(CancellationToken cancellationToken = default);
        Task<T> GetAsync<T>(Guid id, Func<IQueryable<T>, IQueryable<T>> includes = null, CancellationToken cancellationToken = default) where T : AggregateRoot;
        Task<T> GetAsync<T>(Expression<Func<T, bool>> where, Func<IQueryable<T>, IQueryable<T>> includes = null, CancellationToken cancellationToken = default) where T : AggregateRoot;
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        #endregion
    }
}
