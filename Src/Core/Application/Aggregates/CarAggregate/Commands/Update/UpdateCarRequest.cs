using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarAggregate.Commands.Update;

public record UpdateCarRequest
{

    public UpdateCarRequest(int id, string numberPlates, int? branchId, int carModelId, int gearboxId, int mileage, decimal costperday = 1)
    {
        Id = id;
        NumberPlates = numberPlates;
        BranchId = branchId;
        CarModelId = carModelId;
        GearboxId = gearboxId;
        Mileage = mileage;
        Costperday = costperday;
    }

    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string NumberPlates { get; set; }
    public int? BranchId { get; set; }
    public int CarModelId { get; set; }
    public int GearboxId { get; set; }
    public int Mileage { get; set; } = 0;

    [Required]
    [Range(0, 999.99)]
    public decimal Costperday { get; set; }

}
