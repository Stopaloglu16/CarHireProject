using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class CarHireExtra
{
    [Key]
    public int CarHireId { get; set; }
    public CarHireLog CarHire { get; set; }

    [Key]
    public int CarExtraId { get; set; }
    public CarExtra CarExtra { get; set; }

    public decimal ExtraCost { get; set; }

}
