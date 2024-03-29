using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarHireLogAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICarHireRepository : IRepository<CarHireLog, long>
    {
        Task<IEnumerable<CarHireLogDto>> GetCarHiresByBranch(int branchId);
        Task<IEnumerable<CarHireLogDto>> GetCarHiresByCustomer(int userId);

        Task<bool> CheckCarAvabilityById(int Id, DateTime rentFrom, DateTime rentTo);

        Task<IEnumerable<CarHireCarDto>> GetAvailableCars(int pickupBranchId, DateTime pickupDate, DateTime returnDate);

        Task<bool> HireCar(int carId);
    }
}
