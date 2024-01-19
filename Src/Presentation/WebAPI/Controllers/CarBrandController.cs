using CarHire.Services.CarBrands;
using Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    // [Authorize]
    public class CarBrandController : ApiController
    {

        private readonly ICarBrandService _carBrandService;

        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }


        [HttpGet("GetList")]
        public async Task<IEnumerable<SelectListItem>> GetList()
        {
            return await _carBrandService.GetCarBrandList();
        }

        //[HttpGet]
        //public async Task<ActionResult<CarBrandList>> Get()
        //{
        //    return await Mediator.Send(new GetCarBrandsQuery());
        //}




        //[HttpPost]
        //public async Task<ActionResult<int>> Create(CreateCarBrandCommand command)
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
        //public async Task<ActionResult> Update(int id, UpdateCarBrandCommand command)
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
