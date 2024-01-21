namespace Application.Aggregates.CarAggregate.Queries;

public record CarHireCarDto
{
    public int Id { get; set; }

    public int CarBrandId { get; set; }
    public string CarBrandName { get; set; }
    public int CarModelId { get; set; }
    public string CarModelName { get; set; }

    public string CarPhoto { get; set; }

    public int GearboxId { get; set; }
    public string GearboxName { get; set; }

    public decimal Costperday { get; set; }

}
