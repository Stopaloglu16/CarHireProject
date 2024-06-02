using Application.Common.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.Data.EfCore;

public class EfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly ApplicationDbContext context;
    public EfCoreRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IQueryable<TEntity> GetAll()
    {
        return context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetListByBool(bool active)
    {
        return context.Set<TEntity>().Where(ss => ss.IsDeleted != 1);  //Deleted 1 on database
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }


    public async Task<List<TEntity>> ListAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync(new CancellationToken());
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity)
    {
        context.Set<TEntity>().AddRange(entity);
        await context.SaveChangesAsync(new CancellationToken());
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TKey id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        context.Set<TEntity>().Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync(new CancellationToken());
        return entity;
    }

}


