using Domain.Common.Mappings;

namespace Application.Aggregates.WebAggregate.Queries
{
    public class WebMenuDto : IMapFrom<WebMenu>
    {
        public int Id { get; set; }
        public string MainName { get; set; }
        public string SubName { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public int MenuOrder { get; set; }
        public int RoleId { get; set; }
        public string IconName { get; set; }
    }
}
