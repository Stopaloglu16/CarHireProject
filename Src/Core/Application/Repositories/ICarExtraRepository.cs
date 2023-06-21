using Application.Aggregates.CarExtraAggregate.Commands.Create;
using Application.Aggregates.CarExtraAggregate.Commands.Update;
using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.CarExtraAggregate;

namespace Application.Repositories
{

    public interface ICarExtraRepository : IRepository<CarExtra>
    {
        Task<IEnumerable<CarExtraDto>> GetCarExtras();
        Task<CarExtraDto> GetCarExtraById(int Id);
        Task<CreateCarExtraResponse> CreateCarExtra(CreateCarExtraRequest createCarExtraRequest);
        Task<UpdateCarExtraResponse> UpdateCarExtra(UpdateCarExtraRequest updateCarExtraRequest);
    }
}
