using Application.Aggregates.CarModelAggregate.Commands.Create;
using Domain.Entities;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples;
public class CarModelListGenerator
{
    public static IEnumerable<CarModel> Creates => new List<CarModel>
    {
        new() { Name = "CHR", CarPhoto = "", CarPhotoLenght = 1, SeatNumber = 5, CarBrandId = 1 },
        new() { Name = "Aygo", CarPhoto = "", CarPhotoLenght = 1, SeatNumber = 5, CarBrandId = 1 },
        new() { Name = "1 series", CarPhoto = "", CarPhotoLenght = 1, SeatNumber = 5, CarBrandId = 2 },
        new() { Name = "Corsa", CarPhoto = "", CarPhotoLenght = 1, SeatNumber = 5, CarBrandId = 3 },
        new() { Name = "Astra", CarPhoto = "", CarPhotoLenght = 1, SeatNumber = 5, CarBrandId = 3 }
    };
}


public class CarModelGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (CarModel data in CarModelListGenerator.Creates)
            yield return new object[] { data };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// Create list of CreateCarModelRequest data from generator
/// </summary>
public class CarModelRequestGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (CarModel data in CarModelListGenerator.Creates)
            yield return new object[] { new CreateCarModelRequest() { Name = data.Name, CarPhoto = data.CarPhoto, CarPhotoLenght = (int)data.CarPhotoLenght, SeatNumber = data.SeatNumber, CarBrandId = data.CarBrandId } };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
