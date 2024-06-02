using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Utilities;

namespace CarHire.Services.Branchs;

public class BranchService : IBranchService
{

    private readonly IBranchRepository _branchRepository;

    public BranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<IEnumerable<BranchDto>> GetBranches()
    {
        return await _branchRepository.GetBranches();
    }

    public async Task<IEnumerable<SelectListItem>> GetBranchList()
    {
        return await _branchRepository.GetBranchSelectList();
    }


    public async Task<BranchDto> GetBranchById(int Id)
    {
        return await _branchRepository.GetBranchById(Id);
    }


    //public async Task<Branch> DeleteBranchById(int Id)
    //{
    //    return await _branchRepository.DeleteAsync(Id);
    //}

    public async Task<CreateBranchResponse> CreateBranch(CreateBranchRequest branch)
    {
        try
        {
            return await _branchRepository.CreateBranch(branch);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest branch)
    {
        return await _branchRepository.UpdateBranch(branch);
    }

    public async Task<bool> SoftDeleteBranchById(int Id)
    {
        return await _branchRepository.SoftDeleteBranchById(Id);
    }
}
