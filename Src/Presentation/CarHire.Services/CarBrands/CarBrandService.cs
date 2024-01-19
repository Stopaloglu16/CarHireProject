﻿using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarBrandsAggregate;
using Domain.Utilities;

namespace CarHire.Services.CarBrands
{
    public class CarBrandService : ICarBrandService
    {

        private readonly ICarBrandRepository _carBrandRepository;

        public CarBrandService(ICarBrandRepository carBrandRepository)
        {
            _carBrandRepository = carBrandRepository;

        }

        public async Task<CreateCarBrandResponse> Add(CreateCarBrandRequest carBrand)
        {
            var myReturn = await _carBrandRepository.AddAsync(new CarBrand() { Name = carBrand.BrandName });

            if (myReturn == null) return new CreateCarBrandResponse(0, new Domain.Common.BasicErrorHandler("SystemIssue"));

            return new CreateCarBrandResponse(myReturn.Id, new Domain.Common.BasicErrorHandler());
        }

        public async Task<CarBrandDto> GetCarBrandById(int Id)
        {
            return await _carBrandRepository.GetCarBrandById(Id);
        }

        public async Task<IEnumerable<SelectListItem>> GetCarBrandList()
        {
            return await _carBrandRepository.GetCarBrandList();
        }

        public async Task<IEnumerable<CarBrandDto>> GetCarBrands()
        {
            return await _carBrandRepository.GetCarBrands();
        }
    }
}
