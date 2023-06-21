using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateAdminUserRequest : CreateUserRequest
    {

        public CreateAdminUserRequest()
        {
            UserTypeId = (int)UserType.AdminUser;
        }


        [Required]
        public int RoleGroupId { get; set; }


    }
}
