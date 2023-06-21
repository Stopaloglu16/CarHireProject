using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using Domain.Common;

namespace CarHire.Services.CarModelService
{

    public interface ICarModelService
    {
        Task<IEnumerable<CarModelDto>> GetCarModels();

        Task<CarModelDto> GetCarModelById(int Id);

        Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int BrandId);

        Task<IEnumerable<SelectListItem>> GetCarModelList();

        Task<IEnumerable<SelectListItem>> GetCarModelListById(int carBrandId);

        Task<IEnumerable<CarModelDto>> GetCarModelDataListById(int carBrandId);

        Task<CreateCarModelResponse> Add(CreateCarModelRequest carModel);
        Task<UpdateCarModelResponse> Update(UpdateCarModelRequest carModel);

    }

}
