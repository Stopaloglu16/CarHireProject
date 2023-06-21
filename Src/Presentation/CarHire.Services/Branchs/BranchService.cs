using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;

namespace CarHire.Services.Branchs
{
    public class BranchService : IBranchService
    {

        private readonly IBranchRepository _branchRepository;
        private readonly IAddressRepository _addressRepository;

        public BranchService(IBranchRepository branchRepository, IAddressRepository addressRepository)
        {
            _branchRepository = branchRepository;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<BranchDto>> GetBranches()
        {
            return await _branchRepository.GetBranches();
        }

        public async Task<IEnumerable<SelectListItem>> GetBranchList()
        {
            return await _branchRepository.GetBranchList();
        }


        public async Task<BranchDto> GetBranchById(int Id)
        {
            return await _branchRepository.GetBranchById(Id);
        }


        public async Task<Branch> DeleteBranchById(int Id)
        {
            return await _branchRepository.DeleteAsync(Id);
        }

        public async Task<CreateBranchResponse> CreateBranch(CreateBranchRequest branch)
        {
            try
            {

                var myRtn = await _addressRepository.AddAsync(new Address()
                {
                    Id = 0,
                    Address1 = branch.Address.Address1,
                    City = branch.Address.City,
                    Postcode = branch.Address.Postcode,
                    addressType = Domain.Enums.AddressType.BranchAddress
                });

                branch.Address.Id = myRtn.Id;

                return await _branchRepository.CreateBranch(branch);


                //if (myRtn.Id > 0)
                //{
                //    var myBranch = await _branchRepository.AddAsync(new Branch()
                //    {

                //        BranchName = branch.BranchName,
                //        AddressId = myRtn.Id
                //    });

                //    return new CreateBranchResponse(myBranch.Id, new BasicErrorHandler("Address not created"));
                //}


            }
            catch (Exception ex)
            {
                return new CreateBranchResponse(-1, new BasicErrorHandler("Address not created"));
            }
        }

        public async Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest branch)
        {

            //var myAdd = await _addressRepository.GetByIdAsync(branch.Address.Id);
            //await _addressRepository.UpdateAsync(myAdd);

            return await _branchRepository.UpdateBranch(branch);

        }

        public async Task<bool> SoftDeleteBranchById(int Id)
        {
            return await _branchRepository.SoftDeleteBranchById(Id);
        }
    }
}
