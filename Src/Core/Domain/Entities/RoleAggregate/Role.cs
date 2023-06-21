using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.RoleAggregate
{
    public class Role : BaseEntity<int>
    {

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string RoleName { get; set; }

        
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string RoleDisplayName { get; set; }



        [InverseProperty(nameof(RoleUser.Roles))]
        public virtual ICollection<RoleUser> RoleUsers { get; set; }


        public ICollection<RoleGroup> RoleGroups { get; set; }

        [InverseProperty(nameof(RoleRoleGroup.Role))]
        public virtual ICollection<RoleRoleGroup> RoleRoleGroups { get; set; }



    }
}