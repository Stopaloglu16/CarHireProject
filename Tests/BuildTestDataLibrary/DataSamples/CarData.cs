using Application.Aggregates.CarAggregate.Commands.Create;
using Domain.Entities;
using Domain.Enums;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples;


public class CarListGenerator
{
    private readonly static List<string> carNumberPlates = new List<string>();

    public static IEnumerable<Car> Creates =>
    new List<Car>
    {
        new() { NumberPlates = CreatenumberPlate(), CarModelId = 1, Costperday = 10.5m, Mileage = 0, GearboxId = Gearbox.Automatic }
    };


    public static string CreatenumberPlate()
    {
        var rand = new Random();
        string newPlate = "";

        while (true)
        {
            newPlate = string.Concat((char)rand.Next('A', 'Z'), (char)rand.Next('A', 'Z'),
                                           rand.Next(10, 99), " ",
                                           rand.Next(10, 99), (char)rand.Next('A', 'Z'));

            if (!carNumberPlates.Contains(newPlate)) break;
        }

        return newPlate;
    }
}


public class CarGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (Car data in CarListGenerator.Creates)
            yield return new object[] { data };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// Create list of CreateCarRequest data from generator
/// </summary>
public class CarRequestGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (Car data in CarListGenerator.Creates)
            yield return new object[] { new CreateCarRequest(data.NumberPlates, data.BranchId, data.CarModelId, (Gearbox)data.GearboxId, data.Mileage, data.Costperday) };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
