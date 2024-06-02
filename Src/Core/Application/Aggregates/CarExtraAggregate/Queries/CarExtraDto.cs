using Domain.Common.Mappings;
using Domain.Entities;

namespace Application.Aggregates.CarExtraAggregate.Queries;

public record CarExtraDto : IMapFrom<CarExtra>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
}
