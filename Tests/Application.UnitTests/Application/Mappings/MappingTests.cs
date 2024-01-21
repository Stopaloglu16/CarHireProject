using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Aggregates.CarModelAggregate.Queries;
using Application.Aggregates.UserAggregate.Queries;
using AutoMapper;
using Domain.Common.Mappings;
using Domain.Entities.UserAggregate;
using System.Runtime.Serialization;

namespace Application.UnitTests.Application.Mappings
{
    public class MappingTests
    {

        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }


        [Theory]
        [InlineData(typeof(Branch), typeof(BranchDto))]
        [InlineData(typeof(CarBrand), typeof(CarBrandDto))]
        [InlineData(typeof(CarModel), typeof(CarModelDto))]
        [InlineData(typeof(Address), typeof(AddressDto))]
        [InlineData(typeof(Car), typeof(CarDto))]
        [InlineData(typeof(User), typeof(UserDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);
            _mapper.Map(instance, source, destination);
        }


        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }


    }
}
