using Domain.Common.Mappings;
using Domain.Entities.UserAggregate;

namespace Application.Aggregates.RoleAggregate.Queries;

public record RoleGroupDto : IMapFrom<RoleGroup>
{

    public string RoleGroupName { get; set; }

    public int UserTypeID { get; set; }

}
