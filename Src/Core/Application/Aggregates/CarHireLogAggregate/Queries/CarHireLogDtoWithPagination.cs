namespace Application.Aggregates.CarHireAggregate.Queries;


public record CarHireLogDtoWithPagination
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}


public record CarHireLogDtoWithPaging
{
    public CarHireLogDtoWithPaging(int carId, string carPhoto, string carDescription, int pickLocationId, string pickLocation,
                              DateTime pickDatetime, int returnLocationId, string returnLocation, DateTime returnDatetime,
                              decimal totalcost)
    {
        CarId = carId;
        CarPhoto = carPhoto;
        CarDescription = carDescription;
        PickLocationId = pickLocationId;
        PickLocation = pickLocation;
        PickDatetime = pickDatetime;
        ReturnLocationId = returnLocationId;
        ReturnLocation = returnLocation;
        ReturnDatetime = returnDatetime;
        Totalcost = totalcost;
    }

    public int CarId { get; set; }

    public string CarPhoto { get; set; }
    public string CarDescription { get; set; }

    public int PickLocationId { get; set; }
    public string PickLocation { get; set; }
    public DateTime PickDatetime { get; set; }

    public int ReturnLocationId { get; set; }
    public string ReturnLocation { get; set; }
    public DateTime ReturnDatetime { get; set; }

    public decimal Totalcost { get; set; } //Changing with extras

}
