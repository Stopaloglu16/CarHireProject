using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarModelAggregate.Commands.Create;

public record CreateCarModelRequest
{

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public string? CarPhoto { get; set; }

    public int CarPhotoLenght { get; set; }
    public int SeatNumber { get; set; }
    public int CarBrandId { get; set; }

}
