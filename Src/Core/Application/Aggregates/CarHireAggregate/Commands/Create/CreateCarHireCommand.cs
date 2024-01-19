using Application.Common.Interfaces;
using Application.Repositories;
using Domain.Utilities;
using MediatR;

namespace Application.Aggregates.CarHireAggregate.Commands.Create
{
    public class CreateCarHireCommand : IRequest<int>
    {
        public CreateCarHireCommand(int carId, int userId, int pickUpBranchId, DateTime pickUpDate, DateTime pickUpDateTime,
                                    int returnBranchId, DateTime returnDate, DateTime returnDateTime, int returnMileage,
                                    decimal bookingCost, ChosenItemList carExtras = null)
        {
            CarId = carId;
            UserId = userId;
            PickUpBranchId = pickUpBranchId;
            PickUpDate = pickUpDate;
            PickUpDateTime = pickUpDateTime;
            ReturnBranchId = returnBranchId;
            ReturnDate = returnDate;
            ReturnDateTime = returnDateTime;
            ReturnMileage = returnMileage;
            BookingCost = bookingCost;
            CarExtras = carExtras;
        }


        public int CarId { get; set; }
        public int UserId { get; set; }
        public int PickUpBranchId { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public int ReturnBranchId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int ReturnMileage { get; set; }
        public decimal BookingCost { get; set; }

        public ChosenItemList? CarExtras { get; set; } = new ChosenItemList();

    }



    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarHireCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICarHireRepository _repo;

        public CreateCarBrandCommandHandler(IApplicationDbContext context, ICarHireRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<int> Handle(CreateCarHireCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (await _repo.CheckCarAvabilityById(request.CarId, request.PickUpDate, request.ReturnDate))
                {

                    var entity = new CarHireObj();

                    entity.CarId = request.CarId;
                    entity.UserId = request.UserId;
                    entity.BookingCost = request.BookingCost;

                    entity.PickUpBranchId = request.PickUpBranchId;
                    entity.PickUpDate = request.PickUpDate;
                    entity.PickUpDateTime = request.PickUpDateTime;

                    entity.ReturnBranchId = request.ReturnBranchId;
                    entity.ReturnDate = request.ReturnDate;
                    entity.ReturnDateTime = request.ReturnDateTime;


                    foreach (var item in request.CarExtras.myList)
                    {
                        entity.CarExtras.Add(_context.CarExtras.Where(cc => cc.Id == item.ChosenId).First());
                    }


                    _context.CarHires.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);

                    return entity.Id;

                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }

}
