using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using CarHire.Services.Cars;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CarController : ApiController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return await _carService.GetCars();
        }



        [HttpGet("GetByCarId/{Id}")]
        public async Task<CarDto> GetByCarId(int Id)
        {
            return await _carService.GetCarDisplayById(Id);
        }


        [HttpGet("GetByBranch/{branchId}")]
        public async Task<IEnumerable<CarDto>> GetByBranch(int branchId)
        {
            return await _carService.GetCarsByBranchId(branchId);
        }



        [HttpGet("GetByBrandModel/{brandId}/{modelId}")]
        public async Task<IEnumerable<CarDto>> GetByBrandModel(int brandId, int modelId)
        {
            if (modelId == 0)
            {
                return await _carService.GetCarsByBrandId(brandId);
            }
            else
            {
                return await _carService.GetCarsByModelId(modelId);
            }
        }


        [HttpPost]
        public async Task<ActionResult<CreateCarResponse>> Create(CreateCarRequest car)
        {
            try
            {
                return await _carService.Add(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<UpdateCarResponse>> Update(int Id, UpdateCarRequest car)
        {
            try
            {
                if (Id != car.Id) return BadRequest(new UpdateCarResponse(0, new BasicErrorHandler("Id not match")));

                return await _carService.Update(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }

}
