using Application.Aggregates.AddressAggregate.Commands.Create;
using Domain.Entities;
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
                yield return new object[] { new CreateAddressCommand() { Address1 = data.Address1, City = data.City, Postcode = data.Postcode, addressType = AddressType.BranchAddress } };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    //string _Address1, string _City, string _Postcode, AddressType _addressType

}
