using Application.Repositories;
using Domain.Entities.UserAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;

namespace Infrastructure.Repositories.RoleRepos;


public class RoleRepository : EfCoreRepository<Role, int>, IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;
    public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

}
