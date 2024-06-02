using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;
using Domain.Utilities;

namespace CarHire.Services.CarBrands;

public interface ICarBrandService
{

    Task<IEnumerable<CarBrandDto>> GetCarBrands();

    Task<IEnumerable<SelectListItem>> GetCarBrandSelectList();

    Task<CreateCarBrandResponse> Add(CreateCarBrandRequest carBrand);
}
