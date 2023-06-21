using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Domain.Common;

namespace CarHire.Services.Branchs
{
    public interface IBranchService
    {
        Task<BranchDto> GetBranchById(int Id);
        Task<IEnumerable<SelectListItem>> GetBranchList();
        Task<IEnumerable<BranchDto>> GetBranches();
        Task<CreateBranchResponse> CreateBranch(CreateBranchRequest branch);
        Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest branch);
        Task<bool> SoftDeleteBranchById(int Id);

    }
}
