using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class CarBrand : BaseEntity<int>
{

    public CarBrand()
    {

        CarModels = new HashSet<CarModel>();

    }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    public virtual ICollection<CarModel> CarModels { get; private set; } = new List<CarModel>();

}
