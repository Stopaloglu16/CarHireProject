using Application.Common.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.EfCore
{
    public class EfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        //Data/EfCore

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


        public IQueryable<TEntity> IncludeMultiple(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = null;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = context.Set<TEntity>().Include(include);
                }
            }
            else
            {
                query = context.Set<TEntity>();
            }

            return query.Where(cc => cc.Id.Equals(id)).AsQueryable();

        }

        //public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        //{
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query,
        //                  (current, include) => current.Include(include));
        //    }

        //    return query;
        //}


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


    public static class IncludeExtension
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> dbSet,
                                                params Expression<Func<TEntity, object>>[] includes)
                                                where TEntity : class
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query == null ? dbSet : query;
        }
    }

}
