using Domain.Enums;

namespace Domain.UnitTests.EnumTests
{
    public class GearboxEnumTests
    {

        [Theory]
        [InlineData(Gearbox.Manual)]
        public void GearboxManual_EnumValue_Test(Gearbox gearbox)
        {
            Assert.Equal(0, Convert.ToInt32(gearbox));
        }

        [Theory]
        [InlineData(Gearbox.Automatic)]
        public void Automatic_EnumValue_Test(Gearbox gearbox)
        {
            Assert.Equal(1, Convert.ToInt32(gearbox));
        }

    }
}
