using Domain.Enums;

namespace Domain.UnitTests.EnumTests
{
    public class AddressTypeEnumTests
    {
        [Theory]
        [InlineData(AddressType.BranchAddress)]
        public void AddressTypeBranchAddress_EnumValue_Test(AddressType addressType)
        {
            Assert.Equal(1, Convert.ToInt32(addressType));
        }

        [Theory]
        [InlineData(AddressType.CustomerAddress)]
        public void AddressTypeCustomerAddress_EnumValue_Test(AddressType addressType)
        {
            Assert.Equal(2, Convert.ToInt32(addressType));
        }

    }
}
