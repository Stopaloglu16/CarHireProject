using Domain.Common.Mappings;
using Domain.Entities.RoleAggregate;

namespace Application.Aggregates.RoleAggregate.Queries
{
    public class RoleGroupDto : IMapFrom<RoleGroup>
    {

        public string RoleGroupName { get; set; }

        public int UserTypeID { get; set; }

    }
}
