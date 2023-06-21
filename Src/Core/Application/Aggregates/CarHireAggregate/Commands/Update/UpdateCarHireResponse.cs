using Domain.Common;

namespace Application.Aggregates.CarHireAggregate.Commands.Update
{
    public class UpdateCarHireResponse
    {
        public UpdateCarHireResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }
}
