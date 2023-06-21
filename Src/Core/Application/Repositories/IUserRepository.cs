using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.UserAggregate;

namespace Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<UserDto>> GetUsers(bool IsActive, int UserTypeId);

        Task<UserDto> GetUserById(int Id);

        Task<UserDto> GetUserByAspId(string AspId);

        Task<UserDto> GetUserWithRolesById(int Id);

    

    }

}
