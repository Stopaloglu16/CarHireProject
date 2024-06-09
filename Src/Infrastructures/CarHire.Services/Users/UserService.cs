using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Application.Repositories;
using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using Domain.Enums;

namespace CarHire.Services.Users;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<UserDto> GetUserById(int Id)
    {
        return await _userRepository.GetUserById(Id);

    }

    public async Task<IEnumerable<UserDto>> GetUsers(bool IsActive, int UserTypeId)
    {
        return await _userRepository.GetUsers(IsActive, UserTypeId);
    }


    public async Task<CreateUserResponse> AddAdminUser(CreateAdminUserRequest createUserRequest)
    {

        var newUser = new User()
        {
            FullName = createUserRequest.FullName,
            UserEmail = createUserRequest.UserEmail,
            RoleGroupId = createUserRequest.RoleGroupId,
            UserTypeId = (int)UserType.AdminUser,
            RegisterTokenValid = DateTime.UtcNow.AddHours(2)
        };

        var myReturn = await _userRepository.AddAsync(newUser);

        if (myReturn == null) throw new ArgumentNullException("Not saved");

        return new CreateUserResponse(myReturn.RegisterToken);
    }

    public async Task<CreateUserResponse> AddBranchUser(CreateBrancUserRequest createUserRequest)
    {
        var myReturn = await _userRepository.AddAsync(
         new User()
         {
             FullName = createUserRequest.FullName,
             UserEmail = createUserRequest.UserEmail,
             BranchId = createUserRequest.BranchId,
             RoleGroupId = createUserRequest.RoleGroupId,
             UserTypeId = UserType.BranchUser
         });

        if (myReturn == null) throw new ArgumentNullException("Not saved");

        return new CreateUserResponse(myReturn.RegisterToken);
    }

    public async Task<CreateUserResponse> AddCustomerUser(CreateCustomerUserRequest createUserRequest)
    {
        var myReturn = await _userRepository.AddAsync(
         new User()
         {
             FullName = createUserRequest.FullName,
             UserEmail = createUserRequest.UserEmail,
             UserTypeId = UserType.Customer
         });

        if (myReturn == null) throw new ArgumentNullException("Not saved");

        return new CreateUserResponse(myReturn.RegisterToken);
    }

    public Task<UserLogInResponse> GetUserByAccessTokenAsync(string accessToken)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> GetUserByAspId(string AspId)
    {
        return await _userRepository.GetUserByAspId(AspId);
    }
}
