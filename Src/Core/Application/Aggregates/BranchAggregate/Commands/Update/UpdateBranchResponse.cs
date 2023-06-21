using Domain.Common;

namespace Application.Aggregates.BranchAggregate.Commands.Update
{

    public class UpdateBranchResponse
    {
        public UpdateBranchResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }
}
