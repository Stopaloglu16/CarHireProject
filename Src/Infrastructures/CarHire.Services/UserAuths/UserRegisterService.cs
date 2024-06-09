using Application.Repositories;
using Domain.Entities.UserAggregate;

namespace CarHire.Services.UserAuths;

public class UserRegisterService : IUserRegisterService
{

    private readonly IUserRegisterRepository _userRegisterRepository;

    public UserRegisterService(IUserRegisterRepository userRegisterRepository)
    {
        _userRegisterRepository = userRegisterRepository;
    }


    public async Task<User> GetUserByAsync(string Username, string Token)
    {
        return await _userRegisterRepository.GetUserByAsync(Username, Token);
    }

    public async Task<bool> UpdateUserAsync(int UserId, string AspId)
    {
        return await _userRegisterRepository.UpdateUserAsync(UserId, AspId);
    }
}
