using Domain.Enums;

namespace Domain.UnitTests.EnumTests
{
    public class UserEnumTests
    {
        [Theory]
        [InlineData(UserType.AdminUser)]
        public void AdminUser_EnumValue_Test(UserType userType)
        {
            Assert.Equal(0, Convert.ToInt32(userType));
        }

        [Theory]
        [InlineData(UserType.BranchUser)]
        public void BranchUser_EnumValue_Test(UserType userType)
        {
            Assert.Equal(1, Convert.ToInt32(userType));
        }

        [Theory]
        [InlineData(UserType.Customer)]
        public void CustomerUser_EnumValue_Test(UserType userType)
        {
            Assert.Equal(2, Convert.ToInt32(userType));
        }

    }
}
