using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarExtraAggregate.Commands.Create;

public record CreateCarExtraRequest
{

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public decimal Cost { get; set; }

}
