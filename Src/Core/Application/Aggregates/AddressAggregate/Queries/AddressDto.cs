using Domain.Common.Mappings;

namespace Application.Aggregates.AddressAggregate.Queries
{
    public class AddressDto : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string? Address1 { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }

    }
}
