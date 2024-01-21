﻿using Domain.Common;
using Domain.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;


public class CarHireLog : AuditableEntity<int>
{
    public int CarId { get; set; }
    public Car Car { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }


    [ForeignKey("PickUpBranch")]
    public int PickUpBranchId { get; set; }
    public Branch PickUpBranch { get; set; }


    [Column(TypeName = "Date")]
    public DateTime PickUpDate { get; set; }
    public DateTime PickUpDateTime { get; set; }
    public bool PickUpConfirmed { get; set; } = false;
    public int PickupMileage { get; set; }

    [ForeignKey("ReturnBranch")]
    public int ReturnBranchId { get; set; }
    public Branch ReturnBranch { get; set; }

    [Column(TypeName = "Date")]
    public DateTime ReturnDate { get; set; }
    public DateTime ReturnDateTime { get; set; }
    public bool ReturnConfirmed { get; set; } = false;

    public int ReturnMileage { get; set; }
    public decimal BookingCost { get; set; }


    public ICollection<CarExtra> CarExtras { get; set; }

}
