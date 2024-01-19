using Domain.Common;
using Domain.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Branch : AuditableEntity<int>
{

    public Branch()
    {

        Users = new HashSet<User>();
        Cars = new HashSet<Car>();
    }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string BranchName { get; set; } = string.Empty;

    public int AddressId { get; set; }
    public Address Address { get; set; }

    /// <summary>
    /// Map to branch users
    /// </summary>
    public virtual ICollection<User> Users { get; set; }

    public virtual ICollection<Car> Cars { get; set; }



    [InverseProperty("PickUpBranch")]
    public ICollection<CarHireLog> PickUpBranchs { get; set; }

    [InverseProperty("ReturnBranch")]
    public ICollection<CarHireLog> ReturnBranchs { get; private set; }

}
