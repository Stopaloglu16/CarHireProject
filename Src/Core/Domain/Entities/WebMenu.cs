using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class WebMenu : BaseEntity<int>
{

    [Required]
    [Column(TypeName = "varchar(150)")]
    public string MainName { get; set; }

    [Column(TypeName = "varchar(150)")]
    public string SubName { get; set; }

    [Required]
    [Column(TypeName = "varchar(150)")]
    public string LinkName { get; set; }

    [Required]
    [Column(TypeName = "varchar(150)")]
    public string LinkUrl { get; set; }
    public int MenuOrder { get; set; }
    public int RoleId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string IconName { get; set; }

    [Required]
    public int ButtonTypeId { get; set; }

}
