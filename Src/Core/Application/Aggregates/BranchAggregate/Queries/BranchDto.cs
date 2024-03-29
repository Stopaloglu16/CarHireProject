using Domain.Common.Mappings;
using Domain.Entities;
using Domain.Utilities;

namespace Application.Aggregates.BranchAggregate.Queries;

public record BranchDto : IMapFrom<Branch>
{
    public int Id { get; set; }
    public string? BranchName { get; set; }
    public string? Address1 { get; set; }
    public string? City { get; set; }
    public string? Postcode { get; set; }

    public ICollection<ChosenItem> Cars { get; set; } = new List<ChosenItem>();

    public void Mapping(Profile profile)
    {
        var c = profile.CreateMap<Branch, BranchDto>()
                    .ForMember(d => d.Cars, opt => opt.Ignore());
    }
}
