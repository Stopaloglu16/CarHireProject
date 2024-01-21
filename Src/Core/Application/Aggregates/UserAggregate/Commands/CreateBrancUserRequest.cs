using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands;

public class CreateBrancUserRequest : CreateUserRequest
{

    public CreateBrancUserRequest()
    {
        UserTypeId = (int)UserType.BranchUser;
    }


    [Required]
    public int RoleGroupId { get; set; }


    public int? BranchId { get; set; }

}
