using Domain.Common.Mappings;

namespace Domain.Entities.CarHireAggregate.EndPoints;

public class CarHireRemoveRequest : IMapFrom<CarHireLog>
{

    public CarHireRemoveRequest()
    {
    }

    public CarHireRemoveRequest(int _Id)
    {
        Id = _Id;
    }


    public int Id { get; set; }

}
