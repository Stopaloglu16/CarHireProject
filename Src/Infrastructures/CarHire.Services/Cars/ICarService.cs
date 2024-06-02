using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;

namespace CarHire.Services.Cars
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetCars();
        Task<CarDto> GetCarDisplayById(int Id);
        Task<IEnumerable<CarDto>> GetCarsByBranchId(int BranchId);

        //Task<IEnumerable<CarDto>> GetCarsByBrandId(int brandId);
        //Task<IEnumerable<CarDto>> GetCarsByModelId(int modelId);
        Task<CreateCarResponse> Add(CreateCarRequest createCarRequest);
        Task<UpdateCarResponse> Update(UpdateCarRequest updateCarRequest);

    }
}
