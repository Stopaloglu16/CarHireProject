using Application.Aggregates.CarExtraAggregate.Commands.Create;
using Application.Aggregates.CarExtraAggregate.Commands.Update;
using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Repositories;
using Domain.Common;
using Domain.Entities.CarExtraAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CarExtraRepos
{

    public class CarExtraRepository : EfCoreRepository<CarExtra>, ICarExtraRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarExtraRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<CarExtraDto> GetCarExtraById(int Id)
        {
            var carExtra = await GetByIdAsync(Id);

            if (carExtra == null) return null;

            return new CarExtraDto() { Id = carExtra.Id, Name = carExtra.Name, Cost = carExtra.Cost };
        }

        public async Task<IEnumerable<CarExtraDto>> GetCarExtras()
        {
            return await GetListByBool(true).Select(ss => new CarExtraDto
            {
                Id = ss.Id,
                Name = ss.Name,
                Cost = ss.Cost

            }).ToListAsync();
        }

        public async Task<CreateCarExtraResponse> CreateCarExtra(CreateCarExtraRequest createCarExtraRequest)
        {
            var myCarExtra = await AddAsync(new CarExtra()
            {
                Name = createCarExtraRequest.Name,
                Cost = createCarExtraRequest.Cost
            });

            return new CreateCarExtraResponse(myCarExtra.Id, new BasicErrorHandler());
        }


        public async Task<UpdateCarExtraResponse> UpdateCarExtra(UpdateCarExtraRequest updateCarExtraRequest)
        {
            var myCarExtra = await UpdateAsync(new CarExtra()
            {
                Id = updateCarExtraRequest.Id,
                Name = updateCarExtraRequest.Name,
                Cost = updateCarExtraRequest.Cost
            });

            return new UpdateCarExtraResponse(myCarExtra.Id, new BasicErrorHandler());
        }
    }


}
