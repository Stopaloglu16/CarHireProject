using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.CarModelAggregate;

namespace CarHire.Services.CarModelService
{
    public class CarModelService : ICarModelService
    {

        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }


        public async Task<CarModelDto> GetCarModelById(int Id)
        {
            return await _carModelRepository.GetCarModelById(Id);
        }

        public async Task<IEnumerable<SelectListItem>> GetCarModelList()
        {
            return await _carModelRepository.GetCarModelList();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarModelListById(int carBrandId)
        {
            return await _carModelRepository.GetCarModelListById(carBrandId);
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModels()
        {
            return await _carModelRepository.GetCarModels();
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int brandId)
        {
            return await _carModelRepository.GetCarModelsByBrandId(brandId);
        }


        public async Task<CreateCarModelResponse> Add(CreateCarModelRequest carModel)
        {
            return await _carModelRepository.CreateCarModel(carModel);
        }

        public async Task<UpdateCarModelResponse> Update(UpdateCarModelRequest carModel)
        {
            return await _carModelRepository.UpdateCarModel(carModel);
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModelDataListById(int carBrandId)
        {
            return await _carModelRepository.GetCarModelsByBrandId(carBrandId);
        }
    }
}
