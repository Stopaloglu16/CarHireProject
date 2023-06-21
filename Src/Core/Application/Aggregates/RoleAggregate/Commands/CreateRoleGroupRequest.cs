using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.RoleAggregate.Commands
{
    public class CreateRoleGroupRequest
    {
        [Required]
        public string RoleGroupName { get; set; }

        public int UserTypeID { get; set; }
    }
}
