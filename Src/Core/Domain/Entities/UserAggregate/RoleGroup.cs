using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserAggregate;

public class RoleGroup : BaseAuditableEntity<int>
{
    public RoleGroup()
    {
        RoleGroupName = "";
        IsDeleted = 0;
    }


    [Required]
    [Column(TypeName = "varchar(50)")]
    public string RoleGroupName { get; set; }

    public UserType UserTypeId { get; set; }


    [InverseProperty(nameof(User.RoleGroup))]
    public virtual ICollection<User> Users { get; set; }


    public ICollection<Role> Roles { get; set; }


    [InverseProperty(nameof(RoleRoleGroup.RoleGroup))]
    public virtual ICollection<RoleRoleGroup> RoleRoleGroups { get; set; }

}
