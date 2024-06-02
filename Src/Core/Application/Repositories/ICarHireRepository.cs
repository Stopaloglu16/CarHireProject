using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarHireLogAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Repositories;

public interface ICarHireRepository : IRepository<CarHireLog, long>
{

    /// <summary>
    /// Get car hires daily. Ignore logic for date change or swap availability
    /// </summary>
    /// <param name="branchId"></param>
    /// <returns></returns>
    Task<IEnumerable<CarHireLogDto>> GetCarHiresByBranch(int branchId);

    Task<IEnumerable<CarHireLogDto>> GetCarHiresByCustomer(int userId);

    Task<bool> CheckCarAvabilityById(int carId, DateTime rentFrom, DateTime rentTo);

    Task<IEnumerable<CarHireCarDto>> GetAvailableCars(int pickupBranchId, DateTime pickupDate, int returnBranchId, DateTime returnDate);

}
