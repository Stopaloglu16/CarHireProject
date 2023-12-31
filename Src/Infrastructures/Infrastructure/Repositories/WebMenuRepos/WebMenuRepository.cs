﻿using Application.Aggregates.WebAggregate.Queries;
using Application.Repositories;
using Domain.Entities.MenuAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.WebMenuRepos
{

    public class WebMenuRepository : EfCoreRepository<WebMenu>, IWebMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public WebMenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<WebMenuDto>> GetHomeMenu()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WebMenuDto>> GetWebMenu()
        {
            return await GetListByBool(true).Select(ss => new WebMenuDto
            {
                MainName = ss.MainName,
                LinkName = ss.LinkName,
                LinkUrl = ss.LinkUrl,
                MenuOrder = ss.MenuOrder,
                IconName = ss.IconName,
                RoleId  =  ss.RoleId 
            }).ToListAsync();
        }
    }
}
