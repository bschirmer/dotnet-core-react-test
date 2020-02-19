using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PZCheesy.Core.Repositories
{
    /**
     * An interface to decouple the data from the data operator
     * 
     * NB: I borrowed this from https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368.
     * I have been trying to learn more about architecture and I feel like this is a good
     * architectural move.
     */
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
