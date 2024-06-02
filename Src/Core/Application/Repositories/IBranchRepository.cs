using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Utilities;

namespace Application.Repositories;

public interface IBranchRepository : IRepository<Branch, int>
{

    Task<IEnumerable<SelectListItem>> GetBranchSelectList();
    Task<IEnumerable<BranchDto>> GetBranches();
    Task<BranchDto> GetBranchById(int Id);

    Task<CreateBranchResponse> CreateBranch(CreateBranchRequest createBranchRequest);
    Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest updateBranchRequest);

    Task<bool> SoftDeleteBranchById(int Id);
}
