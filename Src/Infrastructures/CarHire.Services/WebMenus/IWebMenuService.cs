using Application.Aggregates.WebAggregate.Queries;

namespace CarHire.Services.WebMenus;

public interface IWebMenuService
{
    Task<IEnumerable<WebMenuDto>> GetHomeMenu();

    //Task<IEnumerable<WebMenuDto>> GetWebMenu(string userId);
}
