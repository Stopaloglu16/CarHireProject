using Domain.Utilities;

namespace Application.Aggregates.BranchAggregate.Commands.Create
{
    public class CreateBranchCarsRequest
    {
        public ICollection<ChosenItem> Cars { get; set; } = new List<ChosenItem>();

    }
}
