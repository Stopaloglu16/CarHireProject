using Application.Aggregates.BranchAggregate.Commands.Create;
using Domain.Entities.BranchAggregate;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples
{

    public class BranchListGenerator
    {
        public static IEnumerable<Branch> Creates =>
        new List<Branch>
        {
            new() {  BranchName = "Derby", AddressId = 1 },
            new() {  BranchName = "London", AddressId = 2 },
            new() {  BranchName = "Leeds", AddressId = 3 }
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
                yield return new object[] { new CreateBranchRequest() { BranchName = data.BranchName } };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
