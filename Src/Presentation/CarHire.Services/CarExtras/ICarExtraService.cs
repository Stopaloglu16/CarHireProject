using Application.Aggregates.CarExtraAggregate.Commands.Create;
using Application.Aggregates.CarExtraAggregate.Commands.Update;
using Application.Aggregates.CarExtraAggregate.Queries;

namespace CarHire.Services.CarExtras;

public interface ICarExtraService
{
    Task<CarExtraDto> GetCarExtraById(int Id);

    Task<IEnumerable<CarExtraDto>> GetCarExtras();

    // Task<CreateCarExtraResponse> Add(CreateCarExtraRequest carBrand);

    Task<CreateCarExtraResponse> CreateCarExtra(CreateCarExtraRequest createCarExtraRequest);
    Task<UpdateCarExtraResponse> UpdateCarExtra(UpdateCarExtraRequest updateCarExtraRequest);
}
