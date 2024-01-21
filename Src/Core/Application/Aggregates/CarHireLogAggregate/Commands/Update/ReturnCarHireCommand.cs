namespace Application.Aggregates.CarHireAggregate.Commands.Update;

public record ReturnCarHireCommand //: IRequest<UpdateCarHireResponse>
{
    public ReturnCarHireCommand(int id, int mileage)
    {
        Id = id;
        Mileage = mileage;
    }

    public int Id { get; set; }
    public int Mileage { get; set; }
}


//public class ReturnCarHireCommandHandler : IRequestHandler<ReturnCarHireCommand, UpdateCarHireResponse>
//{
//    private readonly IApplicationDbContext _context;

//    public ReturnCarHireCommandHandler(IApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<UpdateCarHireResponse> Handle(ReturnCarHireCommand request, CancellationToken cancellationToken)
//    {
//        try
//        {
//            var currentCarHire = await _context.CarHires.FindAsync(request.Id);

//            if (currentCarHire == null) return new UpdateCarHireResponse(-1, new BasicErrorHandler("Not Found"));

//            currentCarHire.ReturnMileage = request.Mileage;
//            currentCarHire.ReturnConfirmed = true;

//            await _context.SaveChangesAsync(cancellationToken);

//            return new UpdateCarHireResponse(0, new BasicErrorHandler());
//        }
//        catch (Exception ex)
//        {
//            return new UpdateCarHireResponse(-1, new BasicErrorHandler(ex.Message));
//        }
//    }

//}
