using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserAggregate;

public class User : BaseAuditableEntity<int>
{
    //public User()
    //{
    //    FullName = "";
    //}


    [Column(TypeName = "varchar(100)")]
    public required string FullName { get; set; }
    
    [Column(TypeName = "varchar(250)")]
    public required string UserEmail { get; set; }


    public UserType UserTypeId { get; set; }


    public int RoleGroupId { get; set; }

    [ForeignKey(nameof(RoleGroupId))]
    [InverseProperty("Users")]
    public virtual RoleGroup RoleGroup { get; set; }


    public string AspId { get; set; }


    public string? RegisterToken { get; set; }
    public DateTime RegisterTokenValid { get; set; }

    [InverseProperty(nameof(RoleUser.Users))]
    public virtual ICollection<RoleUser> RoleUsers { get; set; }


    [InverseProperty(nameof(RefreshToken.User))]
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }


    public virtual ICollection<CarHireLog> CarHires { get; private set; } = new List<CarHireLog>();

    public int? BranchId { get; set; }
    public Branch Branch { get; set; }

}
