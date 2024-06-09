using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands;

public abstract record CreateUserRequest
{

    [Required]
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    [StringLength(50)]
    public string UserEmail { get; set; }


    public UserType UserType { get; init; }

}
