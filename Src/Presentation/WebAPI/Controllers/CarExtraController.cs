using Application.Aggregates.CarExtraAggregate.Commands.Create;
using Application.Aggregates.CarExtraAggregate.Commands.Update;
using Application.Aggregates.CarExtraAggregate.Queries;
using CarHire.Services.CarExtras;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class CarExtraController : ApiController
    {

        private readonly ICarExtraService _carExtraService;

        public CarExtraController(ICarExtraService carExtraService)
        {
            _carExtraService = carExtraService;
        }


        [HttpGet]
        public async Task<IEnumerable<CarExtraDto>> Get()
        {
            return await _carExtraService.GetCarExtras();
        }



        [HttpGet("{Id}")]
        public async Task<CarExtraDto> GetById(int Id)
        {
            return await _carExtraService.GetCarExtraById(Id);
        }


        [HttpPost]
        public async Task<ActionResult<CreateCarExtraResponse>> Create(CreateCarExtraRequest CarExtra)
        {
            try
            {
                return await _carExtraService.CreateCarExtra(CarExtra); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCarExtraResponse>> Update(UpdateCarExtraRequest CarExtra)
        {
            try
            {
                return await _carExtraService.UpdateCarExtra(CarExtra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
