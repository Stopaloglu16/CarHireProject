using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.RoleAggregate.Commands;

public record CreateRoleGroupRequest
{
    [StringLength(50)]
    public required string RoleGroupName { get; set; }

    public int UserTypeID { get; set; }
}
