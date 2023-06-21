using Domain.Entities.UserAuthAggregate.Login;
using Domain.Entities.UserAuthAggregate.Register;

namespace WebUI.Services
{
    public interface IUserService
    {
        public Task<UserLogInResponse> LoginAsync(UserLoginRequest user);
        public Task<UserRegisterResponse> RegisterUserAsync(UserRegisterRequest user);
        public Task<UserLogInResponse> GetUserByAccessTokenAsync(string accessToken);

    }
}
