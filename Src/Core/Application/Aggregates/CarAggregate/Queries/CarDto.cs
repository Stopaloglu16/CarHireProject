﻿using AutoMapper;
using Domain.Common.Mappings;
using Domain.Enums;

namespace Application.Aggregates.CarAggregate.Queries
{
    public class CarDto : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string? NumberPlates { get; set; }

        public int? BranchId { get; set; }
        public string? BranchName { get; set; }

        public int CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public string? CarModelName { get; set; }

        public int GearboxId { get; set; }
        public string? GearboxName { get; set; }
        public int Mileage { get; set; } = 0;

        public decimal Costperday { get; set; }


        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<Car, CarDto>()
                        .ForMember(d => d.BranchName, opt => opt.MapFrom(ss => ss.Branch.BranchName))
                        .ForMember(d => d.GearboxName, opt => opt.MapFrom(ss => ((Gearbox)ss.GearboxId).ToString()))
                        .ForMember(d => d.CarBrandId, opt => opt.Ignore());
        }


    }
}
