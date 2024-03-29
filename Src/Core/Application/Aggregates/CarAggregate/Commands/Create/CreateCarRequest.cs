using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarAggregate.Commands.Create;

public record CreateCarRequest
{
    public CreateCarRequest(string numberPlates, int? branchId, int carModelId, Gearbox gearboxId, int mileage, decimal costperday = 1)
    {
        NumberPlates = numberPlates;
        BranchId = branchId;
        CarModelId = carModelId;
        GearboxId = gearboxId;
        Mileage = mileage;
        Costperday = costperday;
    }


    [Required]
    [StringLength(10)]
    public string NumberPlates { get; set; }
    public int? BranchId { get; set; }
    public int CarModelId { get; set; }
    public Gearbox GearboxId { get; set; }
    public int Mileage { get; set; } = 0;

    [Required]
    [Range(0, 999.99)]
    public decimal Costperday { get; set; }


}
