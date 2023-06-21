using Domain.Common;

namespace Domain.Entities.UserAuthAggregate.Register
{
    public class UserRegisterResponse
    {

        public UserRegisterResponse(int id, BasicErrorHandler basicErrorHandler)
        {
            Id = id;
            this.basicErrorHandler = basicErrorHandler;
        }

        public int Id { get; set; }

        public BasicErrorHandler basicErrorHandler { get; set; } = new BasicErrorHandler();

    }
}
