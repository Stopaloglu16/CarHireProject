﻿using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities.CarModelAggregate;

namespace Application.Repositories
{

    public interface ICarModelRepository : IRepository<CarModel>
    {
        Task<IEnumerable<CarModelDto>> GetCarModels();
        Task<CarModelDto> GetCarModelById(int Id);
        Task<IEnumerable<SelectListItem>> GetCarModelList();
        Task<IEnumerable<SelectListItem>> GetCarModelListById(int carBrandId);
        Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int BrandId);
        Task<CreateCarModelResponse> CreateCarModel(CreateCarModelRequest  createCarModelRequest);
        Task<UpdateCarModelResponse> UpdateCarModel(UpdateCarModelRequest updateCarModelRequest);

    }

}
