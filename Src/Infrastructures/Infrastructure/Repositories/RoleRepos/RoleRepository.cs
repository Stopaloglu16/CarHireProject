using Application.Repositories;
using Domain.Entities.RoleAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;

namespace Infrastructure.Repositories.RoleRepos
{

    public class RoleRepository : EfCoreRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
