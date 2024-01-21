using Application.Common.Interfaces;

namespace Application.Aggregates.AddressAggregate.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAddressCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Address1)
              .MaximumLength(50)
              .NotEmpty();

        RuleFor(v => v.City)
                      .MaximumLength(50)
                      .NotEmpty();
        RuleFor(v => v.Postcode)
              .MaximumLength(10)
              .NotEmpty();
    }

}
