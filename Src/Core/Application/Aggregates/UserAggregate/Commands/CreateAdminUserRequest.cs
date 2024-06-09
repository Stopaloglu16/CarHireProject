using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands;

public record CreateAdminUserRequest : CreateUserRequest
{
    public CreateAdminUserRequest()
    {
        UserType = UserType.AdminUser;
    }


    [Required]
    public int RoleGroupId { get; set; }

}
