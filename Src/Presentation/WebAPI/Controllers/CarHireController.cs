using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.Aggregates.CarHireAggregate.Commands.Update;
using Application.Aggregates.CarHireAggregate.Queries;
using CarHire.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{

    public class CarHireController : ApiController
    {

        private IDistributedCache _cache;
        private readonly IUserService _userService;

        public CarHireController(IDistributedCache cache, IUserService userService)
        {
            _cache = cache;
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarHireCarDto>>> Get([FromQuery] GetAvailableCarsQuery command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarHireCommand command)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var myUser = await _userService.GetUserByAspId(userId);

                command.UserId = myUser.Id;

                return await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CollectCar/{id}")]
        public async Task<ActionResult<UpdateCarHireResponse>> CollectCar(int id, CollectCarHireCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        [HttpPut("ReturnCar/{id}")]
        public async Task<ActionResult<UpdateCarHireResponse>> ReturnCar(int id, ReturnCarHireCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }


        [HttpPost("SetCarHireBookDisplay")]
        public async Task<IActionResult> SetCarHireBookDisplay(CarHireBookDisplay myKeyValue)
        {

            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            await _cache.SetRecordAsync(userId, myKeyValue);

            return Ok();
        }



        [HttpGet("GetCarHireBookDisplay")]
        public async Task<ActionResult<CarHireBookDisplay>> GetCarHireBookDisplay()
        {

            if (User == null) return BadRequest();

            var identity = (ClaimsIdentity)User.Identity;



            var userId = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var carHireBookDisplay = await _cache.GetRecordAsync<CarHireBookDisplay>(userId);

            return Ok(carHireBookDisplay);
        }
    }

}
