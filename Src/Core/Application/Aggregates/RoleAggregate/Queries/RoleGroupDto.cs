using Domain.Common.Mappings;

namespace Application.Aggregates.RoleAggregate.Queries
{
    public class RoleGroupDto : IMapFrom<RoleGroup>
    {

        public string RoleGroupName { get; set; }

        public int UserTypeID { get; set; }

    }
}
