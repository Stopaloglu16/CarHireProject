using Domain.Entities.MenuAggregate;

namespace WebUI.Services
{
    public interface IMenuService
    {
        public Task<List<WebMenu>> GetWebMenu();

        public Task<List<WebMenu>> GetHomemenu();
    }
}
