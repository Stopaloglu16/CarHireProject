using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using Application.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CarRepos;

public class CarRepository : EfCoreRepository<Car, int>, ICarRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CarRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> GetCars()
    {

        //return await GetListByBool(true).Include(bb => bb.CarModel)
        //                                       .ThenInclude(cc => cc.CarBrand)
        //                                       .Include(bb => bb.Branch)
        //                                       //.Include(bb => bb.GearboxId)
        //                                       .Select(ss => new CarDto
        //                                       {
        //                                           Id = ss.Id,
        //                                           NumberPlates = ss.NumberPlates,
        //                                           BranchId = ss.BranchId,
        //                                           BranchName = ss.Branch.BranchName,
        //                                           CarModelName = ss.CarModel.Name,
        //                                           GearboxName = ((Gearbox)ss.GearboxId).ToString(),
        //                                           Mileage = ss.Mileage,
        //                                           Costperday = ss.Costperday
        //                                       }).ToListAsync();


        return await GetListByBool(true).Include(bb => bb.CarModel)
                                                  .ThenInclude(cc => cc.CarBrand)
                                                  .Include(bb => bb.Branch)
                                                  .ProjectTo<CarDto>(_mapper.ConfigurationProvider).ToListAsync();
    }



    public async Task<IEnumerable<CarDto>> GetCarsByBranchId(int branchId)
    {
        return await GetListByBool(true).Include(bb => bb.CarModel)
                                                  .ThenInclude(cc => cc.CarBrand)
                                                  .Include(bb => bb.Branch)
                                                  .Where(bb => bb.BranchId == branchId)
                                                  .ProjectTo<CarDto>(_mapper.ConfigurationProvider).ToListAsync();
    }




    public async Task<IEnumerable<CarDto>> GetCarsByBrandId(int brandId)
    {
        return await GetListByBool(true).Include(bb => bb.CarModel)
                                                 .ThenInclude(cc => cc.CarBrand)
                                                 .Include(bb => bb.Branch)
                                                 .Where(bb => bb.CarModel.CarBrandId == brandId)
                                                 .ProjectTo<CarDto>(_mapper.ConfigurationProvider).ToListAsync();
    }


    public async Task<IEnumerable<CarDto>> GetCarsByModelId(int modelId)
    {
        return await GetListByBool(true).Include(bb => bb.CarModel)
                                                  .ThenInclude(cc => cc.CarBrand)
                                                  .Include(bb => bb.Branch)
                                                  .Where(bb => bb.CarModelId == modelId)
                                                  .ProjectTo<CarDto>(_mapper.ConfigurationProvider).ToListAsync();
    }


    public async Task<CarDto> GetCarById(int Id)
    {

        //return await GetListByBool(true).Include(bb => bb.CarModel)
        //                                        .ThenInclude(cc => cc.CarBrand)
        //                                        .Include(bb => bb.Branch)
        //                                        .Where(bb => bb.CarModelId == modelId)
        //                                        .ProjectTo<CarDto>(_mapper.ConfigurationProvider).ToListAsync();

        return await GetAll().Where(aa => aa.Id == Id)
                             .Include(bb => bb.CarModel)
                             .ThenInclude(cc => cc.CarBrand)
                             .Include(bb => bb.Branch)
                             .Select(ss => new CarDto
                             {
                                 Id = ss.Id,
                                 NumberPlates = ss.NumberPlates.ToString(),
                                 BranchId = ss.BranchId == null ? 0 : ss.BranchId,
                                 BranchName = ss.Branch.BranchName == null ? "" : ss.Branch.BranchName,
                                 CarBrandId = ss.CarModel.CarBrandId,
                                 CarModelId = ss.CarModel.Id,
                                 CarModelName = ss.CarModel.Name,
                                 GearboxName = ((Gearbox)ss.GearboxId).ToString(),
                                 Mileage = ss.Mileage,
                                 Costperday = ss.Costperday

                             }).FirstOrDefaultAsync();

    }

    public async Task<CreateCarResponse> CreateCar(CreateCarRequest createCarRequest)
    {
        var myCar = await AddAsync(new Car()
        {
            BranchId = createCarRequest.BranchId,
            GearboxId = (Gearbox)createCarRequest.GearboxId,
            CarModelId = createCarRequest.CarModelId,
            NumberPlates = createCarRequest.NumberPlates,
            Costperday = createCarRequest.Costperday,
            Mileage = createCarRequest.Mileage,
        });

        return new CreateCarResponse(myCar.Id, new CustomErrorHandler());
    }

    public async Task<UpdateCarResponse> UpdateCar(UpdateCarRequest updateCarRequest)
    {

        var myCar = await UpdateAsync(new Car()
        {
            Id = updateCarRequest.Id,
            BranchId = updateCarRequest.BranchId,
            GearboxId = (Gearbox)updateCarRequest.GearboxId,
            CarModelId = updateCarRequest.CarModelId,
            NumberPlates = updateCarRequest.NumberPlates,
            Costperday = updateCarRequest.Costperday,
            Mileage = updateCarRequest.Mileage,
        });

        return new UpdateCarResponse(myCar.Id, new CustomErrorHandler());
    }


}
