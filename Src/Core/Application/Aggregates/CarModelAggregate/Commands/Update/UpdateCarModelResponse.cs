using Domain.Common;

namespace Application.Aggregates.CarModelAggregate.Commands.Update
{
    public class UpdateCarModelResponse
    {
        public UpdateCarModelResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }


}
