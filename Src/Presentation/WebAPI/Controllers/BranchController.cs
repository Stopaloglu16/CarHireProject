using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using CarHire.Services.Branchs;
using Domain.Common;
using Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class BranchController : ApiController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }


        [HttpGet]
        public async Task<IEnumerable<BranchDto>> Get(bool IsActive)
        {


            return await _branchService.GetBranches();
        }


        [HttpGet("GetList")]
        public async Task<IEnumerable<SelectListItem>> GetList()
        {
            return await _branchService.GetBranchList();
        }


        [HttpGet("{Id}")]
        public async Task<BranchDto> GetById(int Id)
        {
            return await _branchService.GetBranchById(Id);
        }


        [HttpPost]
        public async Task<ActionResult<CreateBranchResponse>> Create(CreateBranchRequest branch)
        {
            try
            {
                return await _branchService.CreateBranch(branch); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<UpdateBranchResponse>> Update(int Id, UpdateBranchRequest branch)
        {
            try
            {
                if (Id != branch.Id) return BadRequest( new CustomErrorHandler("Id not match"));

                return await _branchService.UpdateBranch(branch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPut("{id}")]
        //public async Task<ActionResult<UpdateBranchResponse>> Update(int id, UpdateCarBrandRequest command)
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
