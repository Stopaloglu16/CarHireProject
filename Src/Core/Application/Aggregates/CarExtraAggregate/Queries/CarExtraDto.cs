namespace Application.Aggregates.CarExtraAggregate.Queries;

public record CarExtraDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public bool IsSelected { get; set; }
}
