using Geziyoruz.Entities.Abstract;
using System.Linq.Expressions;

namespace Geziyoruz.DataAccess.Abstract
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
