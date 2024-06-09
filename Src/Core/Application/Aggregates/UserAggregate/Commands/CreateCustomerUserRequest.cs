using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.UserAggregate.Commands;

public record CreateCustomerUserRequest:CreateUserRequest
{

    public CreateCustomerUserRequest()
    { 
        UserType = UserType.Customer;
    }

}
