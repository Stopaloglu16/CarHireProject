using Domain.Common.Mappings;

namespace Application.Aggregates.CarBrandAggregate.Queries
{
    public class CarBrandDto : IMapFrom<CarBrand>
    {
        public CarBrandDto()
        {
            // CarModels = new List<CarModelDto>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        // public virtual IList<CarModelDto> CarModels { get; set; }

    }
}
