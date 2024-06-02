using Application.Repositories;
using Domain.Entities.UserAggregate;
using CarHireInfrastructure.Data;
using CarHireInfrastructure.Data.EfCore;

namespace CarHireInfrastructure.Repositories.RoleRepos;


public class RoleRepository : EfCoreRepository<Role, int>, IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;
    public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

}
