﻿using Application.Aggregates.AddressAggregate.Queries;
using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.BranchAggregate.Commands.Update
{

    public class UpdateBranchRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? BranchName { get; set; }

        public AddressDto? Address { get; set; }

        public List<ChosenItem> carChosenValues { get; set; }

    }
}
