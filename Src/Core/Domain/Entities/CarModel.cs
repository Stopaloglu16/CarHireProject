using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class CarModel : BaseAuditableEntity<int>
{

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; } = string.Empty;

    public string? CarPhoto { get; set; }
    public int? CarPhotoLenght { get; set; }

    public int SeatNumber { get; set; }

    public int CarBrandId { get; set; }
    public CarBrand CarBrand { get; set; }

}
