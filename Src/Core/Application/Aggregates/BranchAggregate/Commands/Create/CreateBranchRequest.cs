﻿using Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.BranchAggregate.Commands.Create;

public record CreateBranchRequest
{

    [StringLength(50)]
    public required string BranchName { get; set; }

    [StringLength(50)]
    public string? Address1 { get; set; }

    [StringLength(50)]
    public string? City { get; set; }

    [StringLength(10)]
    public string? Postcode { get; set; }

    public List<ChosenItem> carChosenValues { get; set; }

}
