using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;
using Domain.Utilities;

namespace CarHire.Services.CarBrands;

public interface ICarBrandService
{
    Task<CarBrandDto> GetCarBrandById(int Id);

    Task<IEnumerable<CarBrandDto>> GetCarBrands();

    Task<IEnumerable<SelectListItem>> GetCarBrandList();

    Task<CreateCarBrandResponse> Add(CreateCarBrandRequest carBrand);
}
