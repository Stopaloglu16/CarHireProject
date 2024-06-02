using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Domain.Entities.UserAuthAggregate.Login;

namespace CarHire.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers(bool IsActive, int UserTypeId);

        Task<UserDto> GetUserById(int Id);

        Task<UserDto> GetUserByAspId(string AspId);

        public Task<UserLogInResponse> GetUserByAccessTokenAsync(string accessToken);

        Task<CreateUserResponse> AddAdminUser(CreateAdminUserRequest createUserRequest);

        Task<CreateUserResponse> AddBranchUser(CreateBrancUserRequest createUserRequest);

        Task<CreateUserResponse> AddCustomerUser(CreateCustomerUserRequest createUserRequest);

    }
}
