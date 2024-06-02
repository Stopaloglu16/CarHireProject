using Domain.Common;

namespace Application.Common.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetListByBool(bool active);
    Task<List<TEntity>> ListAllAsync();
    Task<TEntity> GetByIdAsync(TKey id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TKey id);

}
