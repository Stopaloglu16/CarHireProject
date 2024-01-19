﻿using Application.Aggregates.WebAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IWebMenuRepository : IRepository<WebMenu>
    {
        Task<IEnumerable<WebMenuDto>> GetHomeMenu();

        Task<IEnumerable<WebMenuDto>> GetWebMenu();
    }
}
