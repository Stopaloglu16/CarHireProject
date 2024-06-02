using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserAuthAggregate.Login;

[NotMapped]
public record UserLoginRequest
{
    [StringLength(50)]
    public required string Username { get; init; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
