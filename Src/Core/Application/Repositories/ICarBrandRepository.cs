using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Utilities;

namespace Application.Repositories
{
    public interface ICarBrandRepository : IRepository<CarBrand>
    {
        Task<IEnumerable<CarBrandDto>> GetCarBrands();

        Task<CarBrandDto> GetCarBrandById(int Id);

        Task<IEnumerable<SelectListItem>> GetCarBrandList();

    }

}
