using Domain.Common;

namespace Application.Aggregates.RoleAggregate.Commands
{

    public class CreateRoleGroupResponse
    {
        public CreateRoleGroupResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }


}
