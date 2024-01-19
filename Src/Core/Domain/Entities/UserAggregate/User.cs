using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.UserAggregate;

public class User : BaseEntity<int>
{

    public User()
    {
        FullName = "";
        //RefreshTokens = new HashSet<RefreshToken>();
    }


    [Required]
    [Column(TypeName = "varchar(250)")]
    public string FullName { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string UserName { get; set; }

    [Required]
    [Column(TypeName = "varchar(250)")]
    public string UserEmail { get; set; }


    public int UserTypeId { get; set; }

    [ForeignKey(nameof(UserTypeId))]
    [InverseProperty("Users")]
    public virtual UserType userType { get; set; }



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


    public int? AddressId { get; set; }
    public Address Address { get; set; }

}
