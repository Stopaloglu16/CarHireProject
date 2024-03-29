using Application.Aggregates.CarExtraAggregate.Commands.Create;
using Application.Aggregates.CarExtraAggregate.Commands.Update;
using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Repositories;

namespace CarHire.Services.CarExtras;

public class CarExtraService : ICarExtraService
{

    private readonly ICarExtraRepository _carExtraRepository;

    public CarExtraService(ICarExtraRepository carExtraRepository)
    {
        _carExtraRepository = carExtraRepository;
    }


    public async Task<CarExtraDto> GetCarExtraById(int Id)
    {
        return await _carExtraRepository.GetCarExtraById(Id);
    }

    public async Task<IEnumerable<CarExtraDto>> GetCarExtras()
    {
        return await _carExtraRepository.GetCarExtras();
    }


    public async Task<CreateCarExtraResponse> CreateCarExtra(CreateCarExtraRequest createCarExtraRequest)
    {
        return await _carExtraRepository.CreateCarExtra(createCarExtraRequest);
    }

    public async Task<UpdateCarExtraResponse> UpdateCarExtra(UpdateCarExtraRequest updateCarExtraRequest)
    {
        return await _carExtraRepository.UpdateCarExtra(updateCarExtraRequest);
    }

}
