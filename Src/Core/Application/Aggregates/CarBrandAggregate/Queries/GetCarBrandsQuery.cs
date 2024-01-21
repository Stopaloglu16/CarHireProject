using Application.Common.Interfaces;

namespace Application.Aggregates.CarBrandAggregate.Queries;

public class GetCarBrandsQuery : IRequest<CarBrandList>
{

}

public class GetCarBrandsQueryHandler : IRequestHandler<GetCarBrandsQuery, CarBrandList>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCarBrandsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CarBrandList> Handle(GetCarBrandsQuery request, CancellationToken cancellationToken)
    {
        return new CarBrandList
        {
            carBrandDtos = await _context.CarBrands
                       .ProjectTo<CarBrandDto>(_mapper.ConfigurationProvider)
                       .OrderBy(x => x.Name)
                       .ToListAsync(cancellationToken)
        };
    }
}
