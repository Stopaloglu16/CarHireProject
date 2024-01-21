namespace Application.Aggregates.RoleAggregate.Commands;


public class CreateRoleGroupResponse
{
    public CreateRoleGroupResponse(int id)
    {
        Id = id;
    }

    public int Id { get; set; }


}
