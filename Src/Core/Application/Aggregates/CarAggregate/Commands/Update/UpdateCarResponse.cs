using Domain.Common;

namespace Application.Aggregates.CarAggregate.Commands.Update;

public record UpdateCarResponse
{
    public UpdateCarResponse(int id, CustomErrorHandler basicErrorHandler)
    {
        Id = id;
        this.basicErrorHandler = basicErrorHandler;
    }

    public int Id { get; set; }

    public CustomErrorHandler basicErrorHandler { get; set; } = new CustomErrorHandler();

}
