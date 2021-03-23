using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace UltraNuke.CommonMormon.DDD
{
    public class Repository : IDisposable, IRepository
    {
        #region Private Fields
        private readonly IMediator mediator;
        private readonly DbContext context;
        private IDbContextTransaction transaction;
        #endregion

        #region Constructors
        public Repository(DbContext context, IMediator mediator)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region IRepository<T> Members
        public void Entry<T>(T t) where T : AggregateRoot
        {
            switch (t.AggregateState)
            {
                case AggregateState.Added:
                    context.Set<T>().Add(t);
                    break;
                case AggregateState.Deleted:
                    context.Set<T>().Remove(t);
                    break;
                default:
                    context.Set<T>().Update(t);
                    break;
            }
        }

        public void Save()
        {
            mediator.DispatchDomainEvents(context);
            context.SaveChanges();
        }

        public T Get<T>(Guid id, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot
        {
            return Get(w => w.Id.Equals(id), includes: includes);
        }

        public T Get<T>(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot
        {
            return Query(filter, includes: includes).SingleOrDefault();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public IQueryable<T> QueryByPage<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IQueryable<T>> includes = null) where T : AggregateRoot
        {
            var query = Query(filter, orderBy, includes)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize);

            return query;
        }

        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await mediator.DispatchDomainEventsAsync(context);

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> GetAsync<T>(Guid id, Func<IQueryable<T>, IQueryable<T>> includes = null, CancellationToken cancellationToken = default) where T : AggregateRoot
        {
            return await GetAsync(w => w.Id.Equals(id), includes, cancellationToken);
        }

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>> includes = null, CancellationToken cancellationToken = default) where T : AggregateRoot
        {
            return await Query(filter, includes: includes).SingleOrDefaultAsync(cancellationToken);
        }        

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await transaction.CommitAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await transaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
            context.Dispose();
        }
        #endregion
    }
}
