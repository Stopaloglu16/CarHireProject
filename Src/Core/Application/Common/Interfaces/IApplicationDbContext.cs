using Domain.Entities;
using Domain.Entities.UserAggregate;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarExtra> CarExtras { get; set; }
    public DbSet<CarHireLog> CarHireLogs { get; set; }

    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
