using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class CarHireTests : TestBase
    {

        public CarHireTests()
        {
            UseSqlite();
        }

        private string? myCarBrand;


        [SetUp]
        public void SetUp()
        {
            myCarBrand = "BMW";

        }



        [Test]
        public Task PickCar()
        {

            throw new NotImplementedException();

        }


        [Test]
        public Task ReturnCar()
        {

            throw new NotImplementedException();

        }


    }
}
