using Domain.Entities.UserAggregate;

namespace CarHire.Services.UserAuths
{

    public interface IUserRegisterService
    {

        Task<User> GetUserByAsync(string Username, string Token);

        Task<bool> UpdateUserAsync(int UserId, string AspId);

    }
}
