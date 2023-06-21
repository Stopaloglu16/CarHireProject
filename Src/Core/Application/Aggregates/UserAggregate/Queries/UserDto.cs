using Application.Aggregates.RoleAggregate.Queries;
using AutoMapper;
using Domain.Common.Mappings;
using Domain.Entities.UserAggregate;

namespace Application.Aggregates.UserAggregate.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public int RoleGroupId { get; set; }
        public string RoleGroup { get; set; }

        public string AspId { get; set; }


        public string RegisterToken { get; set; }

        public ICollection<RoleDto> RoleUsers { get; private set; } = new List<RoleDto>();

        //public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        //public int? BranchId { get; set; }
        //public Branch Branch { get; set; }


        //public int? AddressId { get; set; }
        //public Address Address { get; set; }

        //public int? CardDetailId { get; set; }
        //public CardDetail CardDetail { get; set; }


        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<User, UserDto>()
                        .ForMember(d => d.RoleUsers , opt => opt.Ignore());
        }

    }
}
