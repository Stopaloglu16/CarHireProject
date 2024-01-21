﻿using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Aggregates.CarBrandAggregate.Commands.Create;


public record CreateCarBrandCommand : IRequest<int>
{
    public CreateCarBrandCommand(string name)
    {
        Name = name;
    }

    public required string Name { get; set; }
}


public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCarBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = new CarBrand();

        entity.Name = request.Name;

        _context.CarBrands.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
