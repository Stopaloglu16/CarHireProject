using Application.Aggregates.WebAggregate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Services.WebMenus
{
    public interface IWebMenuService
    {
        Task<IEnumerable<WebMenuDto>> GetHomeMenu();

        Task<IEnumerable<WebMenuDto>> GetWebMenu(string userId);
    }
}
