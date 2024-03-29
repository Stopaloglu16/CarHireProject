using Domain.Utilities;

namespace Application.Aggregates.CarHireAggregate.Commands.Create;

public record CreateCarHireCommand : IRequest<int>
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
