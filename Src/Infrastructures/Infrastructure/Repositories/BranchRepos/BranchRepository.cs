﻿using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.BranchAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BranchRepos
{

    public class BranchRepository : EfCoreRepository<Branch>, IBranchRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BranchRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IEnumerable<BranchDto>> GetBranches()
        {
            return await GetListByBool(true).Include(bb => bb.Address)
                                                    .Select(ss => new BranchDto
                                                    {
                                                        Id = ss.Id,
                                                        BranchName = ss.BranchName
                                                         ,
                                                        Address = new AddressDto()
                                                        {
                                                            Address1 = ss.Address.Address1,
                                                            City = ss.Address.City,
                                                            Postcode = ss.Address.Postcode
                                                        }

                                                    }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetBranchList()
        {
            return await GetListByBool(true).Include(bb => bb.Address)
                                                   .Select(ss => new SelectListItem(ss.Id, ss.BranchName)
                                                   ).ToListAsync();
        }


        public async Task<BranchDto> GetBranchById(int Id)
        {

            var myBranch = await GetAll().Include(ss => ss.Cars)
                                               .Include(ss => ss.Address)
                                               .SingleAsync(ss => ss.Id == Id);

            if (myBranch == null) return null;

            var branchDto = new BranchDto()
            {
                Id = myBranch.Id,
                BranchName = myBranch.BranchName,
                Address = new AddressDto()
                {
                    Address1 = myBranch.Address.Address1,
                    City = myBranch.Address.City,
                    Postcode = myBranch.Address.Postcode
                }
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
                    AddressId = createBranchRequest.Address.Id
                };

                foreach (var item in createBranchRequest.carChosenValues)
                {
                    if (item.IsChosen) branch.Cars.Add(_dbContext.Cars.Find(item.ChosenId));
                }


                //_dbContext.Branches.Add(branch);
                //var myBranchId = await _dbContext.SaveChangesAsync();

                var myBranch = await AddAsync(branch);

                return new CreateBranchResponse(myBranch.Id, null);
            }
            catch (Exception ex)
            {
                return new CreateBranchResponse(0, new BasicErrorHandler(ex.Message));
            }
        }

        public async Task<UpdateBranchResponse> UpdateBranch(UpdateBranchRequest updateBranchRequest)
        {
            try
            {

                //var myBranchOrj = await GetByIdAsync(updateBranchRequest.Id);
                var myBranchOrj = await GetAll().Include(ss => ss.Cars)
                                               .Include(ss => ss.Address)
                                               .SingleAsync(ss => ss.Id == updateBranchRequest.Id);



                myBranchOrj.BranchName = updateBranchRequest.BranchName;

               // var myTemp = myBranchOrj.Cars.ToList();


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
                    if(!updateBranchRequest.carChosenValues.Any(s => s.ChosenId == item.Id ))
                    {
                        myBranchOrj.Cars.Remove(_dbContext.Cars.Find(item.Id));
                    }

                }

                //_dbContext.Entry(myBranchOrj).State = EntityState.Modified;
                //await _dbContext.SaveChangesAsync();

                var myRtn = await UpdateAsync(myBranchOrj);

                return new UpdateBranchResponse(updateBranchRequest.Id, null);
                
            }
            catch (Exception ex)
            {
                return new UpdateBranchResponse(0, new BasicErrorHandler(ex.Message));
            }
        }

        public async Task<bool> SoftDeleteBranchById(int Id)
        {
            try
            {
                var myBranchOrj = await GetByIdAsync(Id);

                myBranchOrj.IsDeleted = 1;

                _dbContext.Entry(myBranchOrj).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
