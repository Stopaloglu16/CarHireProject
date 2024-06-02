using Application.Aggregates.RoleAggregate.Queries;
using Domain.Common.Mappings;
using Domain.Entities.UserAggregate;

namespace Application.Aggregates.UserAggregate.Queries;

public record UserDto : IMapFrom<User>
{
    public int Id { get; init; }
    public string FullName { get; init; }
    public string UserEmail { get; init; }
    public int UserTypeId { get; init; }
    public string UserType { get; init; }
    public int RoleGroupId { get; init; }
    public string RoleGroup { get; init; }

    public string AspId { get; init; }

    public string RegisterToken { get; init; }

    public ICollection<RoleDto> RoleUsers { get; private set; } = new List<RoleDto>();


    public void Mapping(Profile profile)
    {
        var c = profile.CreateMap<User, UserDto>()
                    .ForMember(d => d.RoleUsers, opt => opt.Ignore())
                    .ForMember(d => d.UserType, opt => opt.Ignore());
    }

}
