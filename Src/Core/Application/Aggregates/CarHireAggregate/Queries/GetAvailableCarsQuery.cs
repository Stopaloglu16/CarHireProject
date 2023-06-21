using Application.Aggregates.CarAggregate.Queries;
using Application.Common.Interfaces;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Aggregates.CarHireAggregate.Queries
{
    public record GetAvailableCarsQuery : IRequest<IEnumerable<CarHireCarDto>>
    {
        public int pickupBranchId { get; set; }
        public DateTime pickupDate { get; set; }
        public DateTime returnDate { get; set; }

    }


    public class GetAvailableCarsQueryHandler : IRequestHandler<GetAvailableCarsQuery, IEnumerable<CarHireCarDto>>
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

        public async Task<IEnumerable<CarHireCarDto>> Handle(GetAvailableCarsQuery request, CancellationToken cancellationToken)
        {

            return await _repo.GetAvailableCars(request.pickupBranchId, request.pickupDate, request.returnDate);
        }

    }



}
