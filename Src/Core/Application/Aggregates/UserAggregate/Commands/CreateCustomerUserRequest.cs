using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands
{
    public class CreateCustomerUserRequest : CreateUserRequest
    {

        public CreateCustomerUserRequest()
        {
            UserTypeId = (int)UserType.Customer;
        }

        [Required]
        public int RoleGroupId { get; set; }


    }
}
