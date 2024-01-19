using Domain.Entities.UserAggregate;

namespace Application.Repositories
{
    public interface IUserRegisterRepository
    {

        Task<User> GetUserByAsync(string Username, string Token);

        Task<bool> UpdateUserAsync(int UserId, string AspId);

    }
}
