using Domain.Entities.CarBrandsAggregate;
using NUnit.Framework;

namespace CarHireCore.UnitTests.Domain.Entities.CarBrandTests
{
    public class CarBrandAddItem
    {

        private readonly string _testCarBrandName = "ABC";

        [Test]
        public void AddsCarBrandIfNotPresent()
        {
            var carBrand = new CarBrand() { Name = "ABC" };

            Assert.AreEqual(_testCarBrandName, carBrand.Name);

        }

    }
}
