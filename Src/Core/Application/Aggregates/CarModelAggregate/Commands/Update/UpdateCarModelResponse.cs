using Domain.Common;

namespace Application.Aggregates.CarModelAggregate.Commands.Update
{
    public class UpdateCarModelResponse
    {
        public UpdateCarModelResponse(int id, CustomErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public CustomErrorHandler basicErrorHandler { get; set; } = new CustomErrorHandler();

    }


}
