﻿using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Aggregates.CarModelAggregate.Queries;
using Application.Aggregates.UserAggregate.Queries;
using AutoMapper;
using Domain.Common.Mappings;
using Domain.Entities.AddressAggregate;
using Domain.Entities.BranchAggregate;
using Domain.Entities.CarAggregate;
using Domain.Entities.CarBrandsAggregate;
using Domain.Entities.CarModelAggregate;
using Domain.Entities.UserAggregate;
using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace CarHireCore.UnitTests.Common.Mappings
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

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }


        [Test]
        [TestCase(typeof(Branch), typeof(BranchDto))]
        [TestCase(typeof(CarBrand), typeof(CarBrandDto))]
        [TestCase(typeof(CarModel), typeof(CarModelDto))]
        [TestCase(typeof(Address), typeof(AddressDto))]
        [TestCase(typeof(Car), typeof(CarDto))]
        [TestCase(typeof(User), typeof(UserDto))]
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
