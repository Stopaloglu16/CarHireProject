using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using Domain.Enums;
using System.Text;

namespace CarHire.Services.Users
{
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
            try
            {
                var myReturn = await _userRepository.AddAsync(new User()
                {
                    FullName = createUserRequest.FullName,
                    UserEmail = createUserRequest.UserEmail,
                    UserName = createUserRequest.UserName,
                    RoleGroupId = createUserRequest.RoleGroupId,
                    UserTypeId = (int)UserType.AdminUser,
                    AspId = createUserRequest.AspId
                });

                if (myReturn == null) return new CreateUserResponse(-1, new BasicErrorHandler("System Issue"));

                return new CreateUserResponse(myReturn.Id, new BasicErrorHandler());
            }
            catch (Exception ex)
            {
                return new CreateUserResponse(0, new BasicErrorHandler(ex.Message));
            }
        }

        public async Task<CreateUserResponse> AddBranchUser(CreateBrancUserRequest createUserRequest)
        {
            var myReturn = await _userRepository.AddAsync(
             new User()
             {
                 FullName = createUserRequest.FullName,
                 UserEmail = createUserRequest.UserEmail,
                 UserName = createUserRequest.UserName,
                 BranchId = createUserRequest.BranchId,
                 RoleGroupId = createUserRequest.RoleGroupId,
                 UserTypeId = (int)UserType.BranchUser
             });

            if (myReturn == null) return new CreateUserResponse(0, new BasicErrorHandler("System Issue"));


         

            return new CreateUserResponse(myReturn.Id, new BasicErrorHandler());
        }

        public async Task<CreateUserResponse> AddCustomerUser(CreateCustomerUserRequest createUserRequest)
        {
            var myReturn = await _userRepository.AddAsync(
             new User()
             {
                 FullName = createUserRequest.FullName,
                 UserEmail = createUserRequest.UserEmail,
                 UserName = createUserRequest.UserName,
                 RoleGroupId = createUserRequest.RoleGroupId,
                 UserTypeId = (int)UserType.Customer
             });

            if (myReturn == null) return new CreateUserResponse(0, new BasicErrorHandler("System Issue"));

            return new CreateUserResponse(myReturn.Id, new BasicErrorHandler());
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
}
