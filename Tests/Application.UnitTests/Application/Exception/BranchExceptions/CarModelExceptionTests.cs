using Application.Aggregates.CarModelAggregate.Commands.Create;

using SharedFunctionLibrary;
using System.ComponentModel.DataAnnotations;

namespace Application.UnitTests.Application.Exception.CarrierExceptions
{
    public class CarModelExceptionTests
    {
        private CreateCarModelRequest? _createCarModelRequest;
        private string CarModelName = TextGenerator.RandomString(20);
        private string CarModelNameLong = TextGenerator.RandomString(52);

        private string serviceValue = TextGenerator.RandomString(20);
        private string serviceValueLong = TextGenerator.RandomString(52);

        private ICollection<ValidationResult>? results = null;

        [Fact]
        public void CreateCarModel_ShortServiceName_Valid()
        {
            _createCarModelRequest = new CreateCarModelRequest() { Name = CarModelName, CarPhoto = "", CarPhotoLenght = 100, SeatNumber = 5, CarBrandId = 1 };

            Assert.True(ValidateClass.Validate(_createCarModelRequest, out results));
        }

        [Fact]
        public void CreateCarModel_UsingLongServiceName_NotValid()
        {
            _createCarModelRequest = new CreateCarModelRequest() { Name = CarModelNameLong, CarPhoto = "", CarPhotoLenght = 100, SeatNumber = 5, CarBrandId = 1 };

            Assert.False(ValidateClass.Validate(_createCarModelRequest, out results));

            //var resultList = results.ToList();

            //Assert.Contains("50", resultList[0].ErrorMessage);
        }

    }
}
