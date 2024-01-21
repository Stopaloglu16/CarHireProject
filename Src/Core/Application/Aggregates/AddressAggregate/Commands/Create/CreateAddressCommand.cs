using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.AddressAggregate.Commands.Create;

public record CreateAddressCommand : IRequest<int>
{

    [StringLength(50)]
    public required string Address1 { get; set; }

    [StringLength(50)]
    public required string City { get; set; }

    [StringLength(10)]
    public required string Postcode { get; set; }
    public AddressType addressType { get; set; }

}


public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = new Address
        {
            Address1 = request.Address1,
            City = request.City,
            Postcode = request.Postcode,
            addressType = request.addressType
        };

        _context.Addresses.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
