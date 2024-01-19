using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Car : AuditableEntity<int>
{
    public Car()
    {
        CarHires = new HashSet<CarHireLog>();
    }


    [Required]
    [Column(TypeName = "varchar(10)")]
    public string NumberPlates { get; set; }

    public int? BranchId { get; set; }
    public Branch Branch { get; set; }

    public int CarModelId { get; set; }
    public CarModel CarModel { get; set; }

    public Gearbox GearboxId { get; set; }

    public int Mileage { get; set; } = 0;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Costperday { get; set; }


    public virtual ICollection<CarHireLog> CarHires { get; private set; } = new List<CarHireLog>();

}
