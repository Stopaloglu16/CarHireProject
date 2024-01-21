namespace Application.Aggregates.CarModelAggregate.Commands.Update;

public record UpdateCarModelRequest
{
    public UpdateCarModelRequest(int id, string name, string carPhoto, int carPhotoLenght, int seatNumber, int carBrandId)
    {
        Id = id;
        Name = name;
        CarPhoto = carPhoto;
        CarPhotoLenght = carPhotoLenght;
        SeatNumber = seatNumber;
        CarBrandId = carBrandId;
    }


    public int Id { get; init; }

    public required string Name { get; init; }
    public string? CarPhoto { get; init; }
    public int CarPhotoLenght { get; init; }
    public int SeatNumber { get; init; }
    public int CarBrandId { get; init; }

}
