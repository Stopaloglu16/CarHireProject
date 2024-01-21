using Application.Aggregates.CarAggregate.Queries;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Repositories;

namespace Application.Aggregates.CarHireAggregate.Queries;

public record GetAvailableCarsQuery : IRequest<PaginatedList<CarHireCarDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    public int pickupBranchId { get; set; }
    public DateTime pickupDate { get; set; }
    public DateTime returnDate { get; set; }

}


public class GetAvailableCarsQueryHandler : IRequestHandler<GetAvailableCarsQuery, PaginatedList<CarHireCarDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICarHireRepository _repo;

    public GetAvailableCarsQueryHandler(IApplicationDbContext context, IMapper mapper, ICarHireRepository repo)
    {
        _context = context;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<PaginatedList<CarHireCarDto>> Handle(GetAvailableCarsQuery request, CancellationToken cancellationToken)
    {

        //return await _repo.GetAvailableCars(request.pickupBranchId, request.pickupDate, request.returnDate);

        return await _context.Cars
        .Where(x => x.Id == request.ListId)
        .OrderBy(x => x.CarModel.Name)
        .ProjectTo<CarHireCarDto>(_mapper.ConfigurationProvider)
        .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

    }

}
