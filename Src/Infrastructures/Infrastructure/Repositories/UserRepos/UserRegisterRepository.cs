using Application.Repositories;
using CarHireInfrastructure.Data.EfCore;
using CarHireInfrastructure.Data;
using Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.Repositories.UserRepos
{
    public class UserRegisterRepository : EfCoreRepository<User, int>, IUserRegisterRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRegisterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByAsync(string Username, string Token)
        {
            Guid guid = Guid.Parse(Token);

            return await _dbContext.Users.SingleAsync(u => u.UserEmail == Username &&
                                                          u.RegisterToken == guid);
        }

        public async Task<bool> UpdateUserAsync(int UserId, string AspId)
        {
            var currentUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);

            currentUser.AspId = AspId;

            await UpdateAsync(currentUser);

            return true;
        }
    }
}
