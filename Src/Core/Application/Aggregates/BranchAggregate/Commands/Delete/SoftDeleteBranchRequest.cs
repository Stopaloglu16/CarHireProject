namespace Application.Aggregates.BranchAggregate.Commands.Delete;

public record SoftDeleteBranchRequest
{
    public int Id { get; set; }

}
