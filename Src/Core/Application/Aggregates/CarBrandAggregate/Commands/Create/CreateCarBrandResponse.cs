using Domain.Common;

namespace Application.Aggregates.CarBrandAggregate.Commands.Create;


public record CreateCarBrandResponse
{
    public CreateCarBrandResponse(int id, CustomErrorHandler basicErrorHandler)
    {
        Id = id;
        this.basicErrorHandler = basicErrorHandler;
    }

    public int Id { get; set; }

    public CustomErrorHandler basicErrorHandler { get; set; } = new CustomErrorHandler();

}
