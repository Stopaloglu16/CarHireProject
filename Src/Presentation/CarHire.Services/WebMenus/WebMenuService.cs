using Application.Aggregates.WebAggregate.Queries;
using Application.Common.Interfaces;
using Application.Repositories;

namespace CarHire.Services.WebMenus;

public class WebMenuService : IWebMenuService
{
    private readonly IWebMenuRepository _webmenuRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;


    public WebMenuService(IWebMenuRepository webmenuRepository,
        IUserRepository userRepository,
        ICurrentUserService currentUserService)
    {
        _webmenuRepository = webmenuRepository;
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public Task<IEnumerable<WebMenuDto>> GetHomeMenu()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WebMenuDto>> GetWebMenu(string userId)
    {

        var myList = await _webmenuRepository.GetWebMenu();
        var myWebMenu = new List<WebMenuDto>();

        var myidd = _currentUserService.UserId;

        if (userId != null)
        {
            var user = await _userRepository.GetUserByAspId(userId);

            foreach (var item in myList)
            {
                if (user.RoleUsers.Any(cc => cc.Id == item.RoleId))
                {
                    myWebMenu.Add(item);
                }
            }

        }

        foreach (var item in myList)
        {
            if (item.RoleId == 0)
            {
                myWebMenu.Add(item);
            }
        }

        return myWebMenu;
    }
}
