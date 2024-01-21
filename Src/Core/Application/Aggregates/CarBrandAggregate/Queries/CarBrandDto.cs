using Domain.Common.Mappings;
using Domain.Entities;

namespace Application.Aggregates.CarBrandAggregate.Queries;

public record CarBrandDto : IMapFrom<CarBrand>
{
    public CarBrandDto()
    {
        // CarModels = new List<CarModelDto>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }

    // public virtual IList<CarModelDto> CarModels { get; set; }

}
