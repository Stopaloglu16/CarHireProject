using Application.Common.Interfaces;
using CarHire.Services.WebMenus;

namespace WebAPI.Controllers
{

    public class WebMenuController : ApiController
    {

        private readonly IWebMenuService _webmenuService;
        private readonly ICurrentUserService _currentUserService;

        public WebMenuController(IWebMenuService webmenuService, ICurrentUserService currentUserService)
        {
            _webmenuService = webmenuService;
            _currentUserService = currentUserService;
        }

        //[HttpGet("WebMenu")]
        //public async Task<IEnumerable<WebMenuDto>> WebMenu()
        //{

        //    var userId = _currentUserService.UserId;


        //    return await _webmenuService.GetWebMenu(userId);
        //}

    }
}
