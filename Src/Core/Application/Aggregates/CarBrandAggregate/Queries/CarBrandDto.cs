using Domain.Common.Mappings;
using Domain.Entities;

namespace Application.Aggregates.CarBrandAggregate.Queries;

public record CarBrandDto : IMapFrom<CarBrand>
{
    public CarBrandDto()
    {

    }

    public int Id { get; set; }
    public string? Name { get; set; }


}
