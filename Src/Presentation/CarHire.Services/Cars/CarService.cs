using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.BranchAggregate;
using Domain.Entities.CarAggregate;

namespace CarHire.Services.Cars
{

    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public async Task<CarDto> GetCarDisplayById(int Id)
        {
            return await _carRepository.GetCarById(Id);
        }

        public async Task<IEnumerable<CarDto>> GetCars()
        {
            return await _carRepository.GetCars();
        }

      
        public async Task<CreateCarResponse> Add(CreateCarRequest car)
        {
            return await _carRepository.CreateCar(car);

            //if (myReturn == null) return new CreateCarResponse(0, new BasicErrorHandler("SystemIssue"));

            //return new CreateCarResponse(myReturn.Id, new BasicErrorHandler());
        }


        public async Task<UpdateCarResponse> Update(UpdateCarRequest updateCarRequest)
        {

            return await _carRepository.UpdateCar(updateCarRequest);


            //try
            //{
            //    var myCurrenctValue = await _carRepository.GetByIdAsync(updateCarRequest.Id);

            //    myCurrenctValue.BranchId = updateCarRequest.BranchId;
            //    myCurrenctValue.CarModelId = updateCarRequest.CarModelId;
            //    myCurrenctValue.GearboxId = updateCarRequest.Gearbox;
            //    myCurrenctValue.Mileage = updateCarRequest.Mileage;

            //    await _carRepository.UpdateAsync(myCurrenctValue);

            //    return new UpdateCarResponse(updateCarRequest.Id, new BasicErrorHandler());
            //}
            //catch (Exception ex)
            //{
            //    return new UpdateCarResponse(updateCarRequest.Id, new BasicErrorHandler(ex.Message));
            //}

        }



        public async Task<IEnumerable<CarDto>> GetCarsByBranchId(int branchId)
        {
            return await _carRepository.GetCarsByBranchId(branchId);
        }

        public async Task<IEnumerable<CarDto>> GetCarsByBrandId(int brandId)
        {
            return await _carRepository.GetCarsByBrandId(brandId);
        }

        public async Task<IEnumerable<CarDto>> GetCarsByModelId(int modelId)
        {
            return await _carRepository.GetCarsByModelId(modelId);
        }
    }
}
