using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarBrandAggregate.Commands.Create;


public record CreateCarBrandRequest
{

    [StringLength(50)]
    public required string BrandName { get; set; }

}
