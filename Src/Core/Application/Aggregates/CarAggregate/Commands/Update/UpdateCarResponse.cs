using Domain.Common;

namespace Application.Aggregates.CarAggregate.Commands.Update
{
    public class UpdateCarResponse
    {
        public UpdateCarResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();


    }
}
