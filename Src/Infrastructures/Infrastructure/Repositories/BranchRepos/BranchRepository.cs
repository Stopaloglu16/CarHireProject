using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Entities;
using Domain.Utilities;
using CarHireInfrastructure.Data;
using CarHireInfrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.Repositories.BranchRepos;

public class BranchRepository : EfCoreRepository<Branch, int>, IBranchRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BranchRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<BranchDto>> GetBranches()
    {

        return await GetListByBool(true).Select(ss => new BranchDto
        {
            Id = ss.Id,
            BranchName = ss.BranchName,
            Address1 = ss.Address1,
            City = ss.City,
            Postcode = ss.Postcode
        }).ToListAsync();
    }

    public async Task<IEnumerable<SelectListItem>> GetBranchSelectList()
    {
        return await GetListByBool(true).Select(
                ss => new SelectListItem(ss.Id, ss.BranchName)
                                               ).ToListAsync();
    }


    public async Task<BranchDto> GetBranchById(int Id)
    {

        var myBranch = await GetAll().Include(ss => ss.Cars)
                                           .SingleAsync(ss => ss.Id == Id);

        if (myBranch == null) return null;

        var branchDto = new BranchDto()
        {
            Id = myBranch.Id,
            BranchName = myBranch.BranchName,
            Address1 = myBranch.Address1,
            City = myBranch.City,
            Postcode = myBranch.Postcode
        };

        branchDto.Cars = new List<ChosenItem>();

        foreach (var item in myBranch.Cars)
        {
            if (item != null) branchDto.Cars.Add(new ChosenItem() { ChosenId = item.Id, ChosenName = item.NumberPlates, IsChosen = true });
        }

        return branchDto;
    }


    public async Task<CreateBranchResponse> CreateBranch(CreateBranchRequest createBranchRequest)
    {
        try
        {
            var branch = new Branch()
            {
                BranchName = createBranchRequest.BranchName,
                Address1 = createBranchRequest.Address1,
                City = createBranchRequest.City,
                Postcode = createBranchRequest.Postcode
            };

            foreach (var item in createBranchRequest.carChosenValues)
            {
                if (item.IsChosen) branch.Cars.Add(_dbContext.Cars.Find(item.ChosenId));
            }

            //_dbContext.Branches.Add(branch);
            //var myBranchId = await _dbContext.SaveChangesAsync();

            var myBranch = await AddAsync(branch);

            return new CreateBranchResponse(myBranch.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest updateBranchRequest)
    {
        try
        {
            var myBranchOrj = await GetAll().Include(ss => ss.Cars)
                                                  .SingleAsync(ss => ss.Id == updateBranchRequest.Id);

            myBranchOrj.BranchName = updateBranchRequest.BranchName;

            foreach (var myCar in updateBranchRequest.carChosenValues)
            {
                if (myCar.IsChosen)
                {
                    if (!myBranchOrj.Cars.Any(s => s.Id == myCar.ChosenId))
                    {
                        myBranchOrj.Cars.Add(_dbContext.Cars.Find(myCar.ChosenId));
                    }
                }
                else
                {
                    if (myBranchOrj.Cars.Any(s => s.Id == myCar.ChosenId))
                    {
                        myBranchOrj.Cars.Remove(_dbContext.Cars.Find(myCar.ChosenId));
                    }
                }
            }

            foreach (var item in myBranchOrj.Cars.ToList())
            {
                if (!updateBranchRequest.carChosenValues.Any(s => s.ChosenId == item.Id))
                {
                    myBranchOrj.Cars.Remove(_dbContext.Cars.Find(item.Id));
                }
            }


            var myRtn = await UpdateAsync(myBranchOrj);

            return new UpdateBranchResponse(updateBranchRequest.Id);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> SoftDeleteBranchById(int Id)
    {
        var myBranchOrj = await GetByIdAsync(Id);
        myBranchOrj.IsDeleted = 1;

        _dbContext.Entry(myBranchOrj).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();

        return true;
    }
}
