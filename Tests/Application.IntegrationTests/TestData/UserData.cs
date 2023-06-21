﻿using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Domain.Enums;

namespace Application.IntegrationTests.TestData
{
    public class UserData
    {

        public CreateAdminUserRequest CreateAdminUser()
        {
            CreateAdminUserRequest createUserRequest = new CreateAdminUserRequest();

            createUserRequest.FullName = "User Admin";
            createUserRequest.UserEmail = "user@hotmail.com";
            createUserRequest.UserName = "UserAdmin";
            createUserRequest.RoleGroupId = 1;
            createUserRequest.UserTypeId = (int)UserType.AdminUser;
            createUserRequest.AspId = "as213AS3d";

            return createUserRequest;
        }

        public UserDto DisplayAdminUser()
        {
            UserDto userDto = new UserDto();

            return userDto;
        }

        public CreateBrancUserRequest CreateBranchUser()
        {
            CreateBrancUserRequest createUserRequest = new CreateBrancUserRequest();

            return createUserRequest;
        }

        public UserDto DisplayBranchUser()
        {
            UserDto userDto = new UserDto();

            return userDto;
        }

        public CreateCustomerUserRequest CreateCustomerUser()
        {
            CreateCustomerUserRequest createUserRequest = new CreateCustomerUserRequest();

            return createUserRequest;
        }

        public UserDto DisplayCustomerUser()
        {
            UserDto userDto = new UserDto();

            return userDto;
        }
    }
}
