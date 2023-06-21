using Application.Aggregates.CarAggregate.Queries;
using Application.Repositories;
using Dapper;
using Domain.Entities.CarHireAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories.CarHireRepos
{

    public class CarHireRepository : EfCoreRepository<CarHireObj>, ICarHireRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration configuration;

        public CarHireRepository(ApplicationDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            this.configuration = configuration;
        }


        public async Task<bool> CheckCarAvabilityById(int Id, DateTime rentFrom, DateTime rentTo)
        {
            //await Task.Delay(100);

            //   var careHireList = await _context.CarHires.FromSqlRaw("Select * FROM [Portalnow].[dbo].[PostcodeGroups] " +
            //"WHERE Id IN(SELECT[PostcodeGroupId]" +
            //"FROM[Portalnow].[dbo].[CompanyZonePostcodes] " +
            // "WHERE[PostcodeId] = ( " +
            //          "SELECT [Id] FROM[Portalnow].[dbo].[Postcodes] " +
            //          "WHERE IsDeleted = 0 AND PostcodeText = '" + _carId + "') ) ").ToListAsync();


            //var query = from n in db.BDatas
            //            orderby n.AddDate, n.CountryCode
            //            where n.CountryCode == "GB"
            //            && (n.AddDate >= startDate && n.AddDate < endDate)
            //            select n;

            var myRtn = await _dbContext.CarHires.Where(cc => cc.CarId == Id &&
                                                                         (
                                                                         (cc.PickUpDate <= rentFrom &&
                                                                          cc.ReturnDate >= rentFrom) ||
                                                                         (cc.PickUpDate <= rentTo &&
                                                                          cc.ReturnDate >= rentTo)
                                                                         )
                                                                         ).ToListAsync();

            if (myRtn == null)
            {
                return false;
            }
            else if (myRtn.Count == 0)
            {
                return true;
            }
            else if (myRtn.Count > 0)
            {
                return false;
            }
            else
            {
                return false;
            }

        }

        public async Task<IEnumerable<CarHireCarDto>> GetAvailableCars(int pickupBranchId, DateTime pickupDate, DateTime returnDate)
        {

            var parameters = new { PickUpBranchId = pickupBranchId, PickDate = pickupDate, ReturnDate = returnDate };

            var sql = @"SELECT carDt.[Id]
                                      ,[CarModelId]
                                      ,[GearboxId]
	                                  ,CHOOSE (([GearboxId]+1), 'Manual','Automatic') [GearboxName]
                                      ,[Costperday]
	                                  ,carmodelDt.CarPhoto
	                                  ,carDt.CarModelId
	                                  ,carmodelDt.CarBrandId
	                                  ,carbrandDt.Name [CarBrandName] 
	                                  ,carmodelDt.Name [CarModelName]
                            FROM [CarHire].[dbo].[Cars] carDt
                            INNER JOIN dbo.CarModels carmodelDt ON carDt.CarModelId = carmodelDt.Id
                            INNER JOIN dbo.CarBrands carbrandDt ON carmodelDt.CarBrandId = carbrandDt.Id
                            WHERE carDt.BranchId = @PickUpBranchId AND carDt.[IsDeleted] = 0
                            AND carDt.Id NOT IN (
                            SELECT [CarId]
                            FROM [CarHire].[dbo].[CarHires]
                            WHERE [IsDeleted] = 0 AND 
                               (@PickDate BETWEEN PickUpDate AND CASE WHEN @PickUpBranchId != ReturnBranchId THEN DATEADD(dd,2, ReturnDate) ELSE DATEADD(dd,1, ReturnDate) END OR 
	                            @ReturnDate BETWEEN PickUpDate AND CASE WHEN @PickUpBranchId != ReturnBranchId THEN DATEADD(dd,2, ReturnDate) ELSE DATEADD(dd,1, ReturnDate) END ))";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<CarHireCarDto>(sql, parameters);
                return result.ToList();
            }

        }


        //public async Task<IEnumerable<BranchDto>> GetBranches()
        //{

        //    return await GetListByBool(true).Include(bb => bb.Address)
        //                                            .Select(ss => new BranchDto
        //                                            {
        //                                                Id = ss.Id,
        //                                                BranchName = ss.BranchName
        //                                                 ,
        //                                                Address = new AddressDto()
        //                                                {
        //                                                    Address1 = ss.Address.Address1,
        //                                                    City = ss.Address.City,
        //                                                    Postcode = ss.Address.Postcode
        //                                                }

        //                                            }).ToListAsync();
        //}
    }
}
