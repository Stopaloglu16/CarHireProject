﻿using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.CarBrandsAggregate;
using Domain.Entities.CarModelAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Infrastructure.Repositories.CarModelRepos
{

    public class CarModelRepository : EfCoreRepository<CarModel>, ICarModelRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarModelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarModelDto> GetCarModelById(int Id)
        {
            var carModel = await GetByIdAsync(Id);

            if (carModel == null) return null;

            return new CarModelDto()
            {
                Id = carModel.Id,
                Name = carModel.Name,
                CarPhoto = carModel.CarPhoto,
                CarPhotoLenght = carModel.CarPhotoLenght,
                SeatNumber = carModel.SeatNumber
            };
        }

        public async Task<IEnumerable<CarModelDto>> GetCarModels()
        {
            return await GetListByBool(true).Select(ss => new CarModelDto
            {
                Id = ss.Id,
                Name = ss.Name,
                CarPhoto = ss.CarPhoto,
                CarPhotoLenght = ss.CarPhotoLenght,
                SeatNumber = ss.SeatNumber
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarModelList()
        {
            return await GetListByBool(true).Select(ss => new SelectListItem(ss.Id, ss.Name))
                                                  .ToListAsync();
        }


        public async Task<IEnumerable<CarModelDto>> GetCarModelsByBrandId(int BrandId)
        {
            return await GetListByBool(true).Where(tt => tt.CarBrandId == BrandId).Select(ss => new CarModelDto
            {
                Id = ss.Id,
                Name = ss.Name,
                CarPhoto = ss.CarPhoto,
                CarPhotoLenght = ss.CarPhotoLenght,
                SeatNumber = ss.SeatNumber
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarModelListById(int carBrandId)
        {
            return await GetListByBool(true).Where(cc => cc.CarBrandId == carBrandId)
                                                  .Select(ss => new SelectListItem(ss.Id, ss.Name))
                                                  .ToListAsync();
        }

        public async Task<CreateCarModelResponse> CreateCarModel(CreateCarModelRequest createCarModelRequest)
        {

            var myResponse = await AddAsync(new CarModel()
            {
                Name = createCarModelRequest.Name,
                CarPhoto = createCarModelRequest.CarPhoto,
                CarPhotoLenght = createCarModelRequest.CarPhotoLenght,
                SeatNumber = createCarModelRequest.SeatNumber,
                CarBrandId = createCarModelRequest.CarBrandId
            });

            if (myResponse.Id > 0)
            {
                return new CreateCarModelResponse(myResponse.Id, new BasicErrorHandler());
            }
            else
            {
                return new CreateCarModelResponse(myResponse.Id, new BasicErrorHandler("Repo issue"));
            }
        }

        public async Task<UpdateCarModelResponse> UpdateCarModel(UpdateCarModelRequest updateCarModelRequest)
        {
            var myResponse = await UpdateAsync(new CarModel()
            {
                Id = updateCarModelRequest.Id,
                Name = updateCarModelRequest.Name,
                CarPhoto = updateCarModelRequest.CarPhoto,
                CarPhotoLenght = updateCarModelRequest.CarPhotoLenght,
                SeatNumber = updateCarModelRequest.SeatNumber,
                CarBrandId = updateCarModelRequest.CarBrandId
            });

            if (myResponse.Id > 0)
            {
                return new UpdateCarModelResponse(myResponse.Id, new BasicErrorHandler());
            }
            else
            {
                return new UpdateCarModelResponse(myResponse.Id, new BasicErrorHandler("Repo issue"));
            }
        }

     
    }

}
