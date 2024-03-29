using Application.Aggregates.RoleAggregate.Queries;
using Application.Aggregates.UserAggregate.Queries;
using Application.Repositories;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserRepos;

public class UserRepository : EfCoreRepository<User, int>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto> GetUserByAspId(string AspId)
    {
        var myuser = await _dbContext.Users.Include(uu => uu.RoleUsers)
                                           .Where(uu => uu.AspId == AspId)
                                           .FirstAsync();
        if (myuser == null) return null;

        var myUserDto = new UserDto()
        {
            Id = myuser.Id,
            FullName = myuser.FullName,
            UserEmail = myuser.UserEmail,
            RoleGroupId = myuser.RoleGroupId,
            UserTypeId = (int)myuser.UserTypeId
        };

        foreach (var item in myuser.RoleUsers)
        {
            myUserDto.RoleUsers.Add(new RoleDto() { Id = item.RolesId });
        }

        return myUserDto;
    }

    public async Task<UserDto> GetUserById(int Id)
    {

        var myuser = await _dbContext.Users.Include(uu => uu.RoleGroup)
                                             .Where(uu => uu.Id == Id)
                                             .FirstAsync();
        if (myuser == null) return null;

        var myUserDto = new UserDto()
        {
            Id = myuser.Id,
            FullName = myuser.FullName,
            UserEmail = myuser.UserEmail,
            //UserName = myuser.UserName,
            RoleGroupId = myuser.RoleGroupId,
            UserTypeId = (int)myuser.UserTypeId
        };

        foreach (var item in myuser.RoleUsers)
        {
            myUserDto.RoleUsers.Add(new RoleDto() { Id = item.RolesId });
        }

        return myUserDto;

    }

    public async Task<IEnumerable<UserDto>> GetUsers(bool IsActive, int UserTypeId)
    {
        return await GetListByBool(IsActive).Where(uu => uu.UserTypeId == (UserType)UserTypeId)
                                             .Select(ss => new UserDto()
                                             {
                                                 FullName = ss.FullName ,
                                                 UserType = ((UserType)ss.UserTypeId).ToString()

                                             }).ToListAsync();
    }

    public async Task<UserDto> GetUserWithRolesById(int Id)
    {
        var user = await GetByIdAsync(Id);

        return new UserDto()
        {
            Id = Id,
            FullName = user.FullName,
            AspId = user.AspId,
            //UserName = user.UserName,
            UserEmail = user.UserEmail,
        };
    }

}
