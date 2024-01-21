using Domain.Common.Mappings;
using Domain.Entities;

namespace Application.Aggregates.AddressAggregate.Queries;

public record AddressDto : IMapFrom<Address>
{
    public int Id { get; set; }
    public string? Address1 { get; set; }
    public string? City { get; set; }
    public string? Postcode { get; set; }

}
