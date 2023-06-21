using Application.Common.Interfaces;
using Domain.Entities.RoleAggregate;

namespace Application.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {

        //Task<IEnumerable<RoleDto>> GetCars();


    }
}
