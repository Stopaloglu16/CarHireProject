using Application.Repositories;
using Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Services.UserAuths
{
    public class UserRegisterService : IUserRegisterService
    {

        private readonly IUserRegisterRepository _dbRepository;

        public UserRegisterService(IUserRegisterRepository productRepository)
        {
            _dbRepository = productRepository;
        }


        public async Task<User> GetUserByAsync(string Username, string Token)
        {
            return await _dbRepository.GetUserByAsync(Username, Token);
        }

        public async Task<bool> UpdateUserAsync(int UserId, string AspId)
        {
            return await _dbRepository.UpdateUserAsync(UserId, AspId);
        }
    }
}
