using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.CarAggregate.Queries;
using AutoMapper;
using Domain.Common;
using Domain.Common.Mappings;
using Domain.Entities.BranchAggregate;
using Domain.Entities.CarAggregate;

namespace Application.Aggregates.BranchAggregate.Queries
{
    public class BranchDto : IMapFrom<Branch>
    {
        public int Id { get; set; }

        public string? BranchName { get; set; }

        public AddressDto? Address { get; set; } = new AddressDto();

        public ICollection<ChosenItem> Cars { get; set; } = new List<ChosenItem>();


        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<Branch, BranchDto>()
                        .ForMember(d => d.Cars, opt => opt.Ignore());
        }
    }
}
