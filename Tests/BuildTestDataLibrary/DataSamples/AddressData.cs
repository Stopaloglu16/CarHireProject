using Application.Aggregates.AddressAggregate.Commands.Create;
using Domain.Entities.AddressAggregate;
using Domain.Enums;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples
{
    public class AddressListGenerator
    {
        public static IEnumerable<Address> Creates =>
        new List<Address>
        {
            new() {  Address1 = "1 street", City = "Derby", Postcode = "DE21 1AB", addressType = AddressType.BranchAddress },
            new() {  Address1 = "2 street", City = "London", Postcode = "RH6 0NP", addressType = AddressType.BranchAddress },
            new() {  Address1 = "3 street", City = "Leeds", Postcode = "LS7 1AG", addressType = AddressType.BranchAddress },
        };
    }


    public class AddressGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (Address data in AddressListGenerator.Creates)
                yield return new object[] { data };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    /// Create list of CreateAddressRequest data from generator
    /// </summary>
    public class AddressRequestGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (Address data in AddressListGenerator.Creates)
                yield return new object[] { new CreateAddressCommand(data.Address1, data.City, data.Postcode, data.addressType) };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
