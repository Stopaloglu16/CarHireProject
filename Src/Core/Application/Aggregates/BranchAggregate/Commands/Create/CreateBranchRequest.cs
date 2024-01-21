using Application.Aggregates.AddressAggregate.Queries;
using Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.BranchAggregate.Commands.Create;

public class CreateBranchRequest
{

    [StringLength(50)]
    public required string BranchName { get; set; }

    public AddressDto? Address { get; set; }

    public List<ChosenItem> carChosenValues { get; set; }

}
