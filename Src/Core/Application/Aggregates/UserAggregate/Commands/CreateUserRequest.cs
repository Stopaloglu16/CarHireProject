using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands;

public abstract class CreateUserRequest
{

    [Required]
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    [StringLength(50)]
    public string UserName { get; set; }

    [Required]
    [StringLength(50)]
    public string UserEmail { get; set; }

    [Required]
    public int UserTypeId { get; set; }

    public UserType UserType { get; set; }

    [Required]
    [StringLength(50)]
    public string AspId { get; set; }
}
