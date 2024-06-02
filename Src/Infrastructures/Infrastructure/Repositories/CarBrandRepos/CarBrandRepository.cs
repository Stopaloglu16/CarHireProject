using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Repositories;
using Domain.Entities;
using Domain.Utilities;
using CarHireInfrastructure.Data;
using CarHireInfrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.Repositories.CarBrandRepos;

public class CarBrandRepository : EfCoreRepository<CarBrand, int>, ICarBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CarBrandRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CarBrandDto> GetCarBrandById(int Id)
    {
        var carBrand = await GetByIdAsync(Id);

        if (carBrand == null) return null;

        return new CarBrandDto() { Id = carBrand.Id, Name = carBrand.Name };
    }

    public async Task<IEnumerable<SelectListItem>> GetCarBrandSelectList()
    {
        return await GetListByBool(true).Select(ss => new SelectListItem(ss.Id, ss.Name))
                                               .ToListAsync();
    }

    public async Task<IEnumerable<CarBrandDto>> GetCarBrands()
    {
        return await GetListByBool(true).Select(ss => new CarBrandDto
        {
            Id = ss.Id,
            Name = ss.Name
        }).ToListAsync();
    }
}
