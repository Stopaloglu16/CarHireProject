using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using CarHire.Services.CarModelService;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class CarModelController : ApiController
    {

        private readonly ICarModelService _carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }



        //[HttpGet]
        //public async Task<ActionResult<CarModelList>> Get()
        //{
        //    return await Mediator.Send(new GetCarModelsQuery());
        //}


        [HttpGet("GetList")]
        public async Task<IEnumerable<SelectListItem>> GetList()
        {
            return await _carModelService.GetCarModelList();
        }

        [HttpGet("GetList/{BrandId}")]
        public async Task<IEnumerable<SelectListItem>> GetListById(int BrandId)
        {
            return await _carModelService.GetCarModelListById(BrandId);
        }


        [HttpGet("GetDataList/{BrandId}")]
        public async Task<IEnumerable<CarModelDto>> GetDataListById(int BrandId)
        {
            return await _carModelService.GetCarModelDataListById(BrandId);
        }


        [HttpGet("{Id}")]
        public async Task<CarModelDto> GetById(int Id)
        {
            return await _carModelService.GetCarModelById(Id);
        }



        [HttpPost]
        public async Task<ActionResult<CreateCarModelResponse>> Create(CreateCarModelRequest branch)
        {
            try
            {
                return await _carModelService.Add(branch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<UpdateCarModelResponse>> Update(int Id, UpdateCarModelRequest branch)
        {
            try
            {
                if (Id != branch.Id) return BadRequest(new UpdateCarModelResponse(0, new BasicErrorHandler("Id not match")));

                return await _carModelService.Update(branch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<int>> Create(CreateCarModelCommand command)
        //{
        //    try
        //    {
        //        return await Mediator.Send(command);
        //    }
        //    catch (Exception ex)
        //    {
        //        await Task.Delay(500);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, UpdateCarModelCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

    }
}
