using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities.BranchAggregate;

namespace Application.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<BranchDto>> GetBranches();
        Task<IEnumerable<SelectListItem>> GetBranchList();
        Task<BranchDto> GetBranchById(int Id);
        Task<CreateBranchResponse> CreateBranch(CreateBranchRequest createBranchRequest);
        Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest updateBranchRequest);
        Task<bool> SoftDeleteBranchById(int Id);

    }

}
