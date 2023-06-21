using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Aggregates.CarHireAggregate.Commands.Update
{
    public class CollectCarHireCommand : IRequest<UpdateCarHireResponse>
    {
        public CollectCarHireCommand(int id, int mileage)
        {
            Id = id;
            Mileage = mileage;
        }

        public int Id { get; set; }
        public int Mileage { get; set; }
    }


    public class CollectCarHireCommandHandler : IRequestHandler<CollectCarHireCommand, UpdateCarHireResponse>
    {
        private readonly IApplicationDbContext _context;

        public CollectCarHireCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCarHireResponse> Handle(CollectCarHireCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var currentCarHire = await _context.CarHires.FindAsync(request.Id);

                if (currentCarHire == null) return new UpdateCarHireResponse(-1, new BasicErrorHandler("Not Found"));

                currentCarHire.PickupMileage = request.Mileage;
                currentCarHire.PickUpConfirmed = true;

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateCarHireResponse(0, new BasicErrorHandler());
            }
            catch (Exception ex)
            {
                return new UpdateCarHireResponse(-1, new BasicErrorHandler(ex.Message));
            }
        }

    }

}
