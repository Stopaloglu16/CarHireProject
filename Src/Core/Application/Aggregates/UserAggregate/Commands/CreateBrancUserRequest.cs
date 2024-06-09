using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands;

public record CreateBrancUserRequest : CreateUserRequest
{
    public CreateBrancUserRequest()
    {
        UserType = UserType.BranchUser;
    }

    [Required]
    public int RoleGroupId { get; set; }

    public int? BranchId { get; set; }
}
