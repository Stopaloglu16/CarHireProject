﻿using Application.Aggregates.AddressAggregate.Queries;
using Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.BranchAggregate.Commands.Create
{
    public class CreateBranchRequest
    {

        [Required]
        [StringLength(50)]
        public string? BranchName { get; set; }

        public AddressDto? Address { get; set; }

        public List<ChosenItem> carChosenValues { get; set; }

    }


}
