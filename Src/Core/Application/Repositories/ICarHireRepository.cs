using Application.Aggregates.CarAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.CarHireAggregate;

namespace Application.Repositories
{
    public interface ICarHireRepository : IRepository<CarHireObj>
    {
        //Task<IEnumerable<CarHireDto>> GetCarHires();

        Task<bool> CheckCarAvabilityById(int Id, DateTime rentFrom, DateTime rentTo);

        Task<IEnumerable<CarHireCarDto>> GetAvailableCars(int pickupBranchId, DateTime pickupDate, DateTime returnDate);

    }
}
