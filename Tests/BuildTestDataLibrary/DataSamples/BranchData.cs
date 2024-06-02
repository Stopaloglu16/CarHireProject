using Application.Aggregates.BranchAggregate.Commands.Create;
using Domain.Entities;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples;

public class BranchListGenerator
{
    public static IEnumerable<Branch> Creates =>
    new List<Branch>
    {
        new() {  BranchName = "Derby", Address1 = "123 Elm Street", City = "Derby", Postcode = "DE1 1AA" },
        new() {  BranchName = "Leeds", Address1 = "456 Oak Avenue", City = "Leeds", Postcode = "LS1 2BB" },
        new() {  BranchName = "London 1", Address1 = "789 Pine Road", City = "London", Postcode = "SW1A 1AA" }
    };
}


public class BranchGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (Branch data in BranchListGenerator.Creates)
            yield return new object[] { data };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// Create list of CreateBranchRequest data from generator
/// </summary>
public class BranchRequestGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (Branch data in BranchListGenerator.Creates)
            yield return new object[] { new CreateBranchRequest() {
                BranchName = data.BranchName,
                Address1 = data.Address1,
                City = data.City,
                Postcode = data.Postcode
            } };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
