using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICarRepository : IRepository<Car, int>
    {
        Task<IEnumerable<CarDto>> GetCars();
        Task<CarDto> GetCarById(int Id);
        Task<IEnumerable<CarDto>> GetCarsByBranchId(int BranchId);
        //Task<IEnumerable<CarDto>> GetCarsByBrandId(int brandId);
        //Task<IEnumerable<CarDto>> GetCarsByModelId(int modelId);
        Task<CreateCarResponse> CreateCar(CreateCarRequest createCarRequest);
        Task<UpdateCarResponse> UpdateCar(UpdateCarRequest updateCarRequest);
    }
}
