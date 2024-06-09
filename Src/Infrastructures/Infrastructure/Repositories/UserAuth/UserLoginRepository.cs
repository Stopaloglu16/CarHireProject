using Application.Repositories;
using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using CarHireInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.Repositories.UserAuth;

public class UserLoginRepository : IUserLoginRepository
{

    private readonly ApplicationDbContext _dbContext;

    public UserLoginRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserLogInResponse> GetUserDetailsAsync(string AspId)
    {
        try
        {
            var myuser = await _dbContext.Users.Where(uu => uu.AspId == AspId)
                                                      .Include(uu => uu.RoleUsers)
                                                      .FirstOrDefaultAsync();

            if (myuser == null)
                throw new ArgumentNullException("Not found user");

            //var myRoles = _dbContext.Roles.ToList();

            //List<Role> roles = new List<Role>();

            //foreach (Role myitem in myRoles)
            //{
            //    if (myuser.RoleUsers.Any(rr => rr.RolesId == myitem.Id))
            //    {
            //        roles.Add(myitem);
            //    }
            //}


            UserLogInResponse userLogInResponse = new UserLogInResponse
            {
                AspId = AspId,
                UserName = myuser.UserEmail,
                AccessToken = "",
                RefreshToken = "",
                UserEmail = myuser.UserEmail,
                Id = myuser.Id,
                UserType = myuser.UserTypeId
                //myRoles = roles,
                //pnErrorHandler = new PnErrorHandler()
            };


            return userLogInResponse;

        }
        catch (System.Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> SaveRefreshTokenAsync(RefreshToken refreshToken, int _UserId)
    {
        _dbContext.RefreshTokens.Add(
                   new RefreshToken
                   {
                       UserId = _UserId,
                       Token = refreshToken.Token,
                       ExpiryDate = refreshToken.ExpiryDate
                   });

        await _dbContext.SaveChangesAsync();

        return true;
    }

}
