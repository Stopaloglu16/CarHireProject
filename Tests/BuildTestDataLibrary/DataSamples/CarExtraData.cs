using Application.Aggregates.CarExtraAggregate.Commands.Create;
using Domain.Entities;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples;

public class CarExtraListGenerator
{
    public static IEnumerable<CarExtra> Creates =>
    new List<CarExtra>
    {
        new() { Name = "Navigation", Cost = 5 },
        new() { Name = "Baby Seat", Cost = 10 }
    };
}


public class CarExtraGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (CarExtra data in CarExtraListGenerator.Creates)
            yield return new object[] { data };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// Create list of CreateCarExtraRequest data from generator
/// </summary>
public class CarExtraRequestGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (CarExtra data in CarExtraListGenerator.Creates)
            yield return new object[] { new CreateCarExtraRequest() { Name = data.Name, Cost = data.Cost } };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
