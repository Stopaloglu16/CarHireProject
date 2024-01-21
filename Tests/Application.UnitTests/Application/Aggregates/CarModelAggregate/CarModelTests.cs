using Application.Aggregates.CarModelAggregate.Commands.Create;

namespace Application.UnitTests.Application.Aggregates.CarrierAggregate
{
    public class CarModelTests
    {
        private CarModel? _carModel;
        private string name = "Demo carmodel";

        private CarModel CreateCarModel()
        {
            var carModel = new CarModel();
            carModel.Name = "Demo carmodel";

            return carModel;
        }


        [Fact]
        public void New_Initializes_Success()
        {
            _carModel = CreateCarModel();

            Assert.Equal(name, _carModel.Name);
        }

        [Fact]
        public void Create_WithMinParameters_Success()
        {
            var carModel = new CarModel() { Name = name };

            Assert.Equal(name, carModel.Name);
        }

        [Theory]
        [InlineData("newCarModel", "newCarPhoto", 100, 5, 1)]
        public void Create_WithAllParameters_Success(string name, string carPhoto, int carPhotoLenght, int seatNumber, int carBrandId)
        {
            var _createCarModelRequest = new CreateCarModelRequest()
            {
                Name = name,
                CarPhoto = carPhoto,
                CarPhotoLenght = carPhotoLenght,
                SeatNumber = seatNumber,
                CarBrandId = carBrandId
            };

            Assert.Equal(name, _createCarModelRequest.Name);
        }

    }
}
