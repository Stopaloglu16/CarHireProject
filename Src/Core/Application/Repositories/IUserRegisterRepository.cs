using Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRegisterRepository
    {

        Task<User> GetUserByAsync(string Username, string Token);

        Task<bool> UpdateUserAsync(int UserId, string AspId);

    }
}
