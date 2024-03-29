using Application.Common.Interfaces;
using Domain.Entities.UserAggregate;

namespace Application.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>
    {

        //Task<IEnumerable<RoleDto>> GetCars();


    }
}
