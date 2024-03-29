using Domain.Common;

namespace Application.Aggregates.CarAggregate.Commands.Create;

public record CreateCarResponse
{
    public CreateCarResponse(int id, CustomErrorHandler basicErrorHandler)
    {
        Id = id;
        this.basicErrorHandler = basicErrorHandler;
    }

    public int Id { get; set; }

    public CustomErrorHandler basicErrorHandler { get; set; } = new CustomErrorHandler();

}
