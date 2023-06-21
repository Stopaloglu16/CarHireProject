using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{
    public class CarBrandData
    {

        private readonly string[] carBrandArray;

        public CarBrandData()
        {
            carBrandArray = new string[4] { "BMW", "Toyota", "Audi", "Opel" };
        }


        public IEnumerable<CreateCarBrandRequest> CreateCarBrandData()
        {

            var myList = new List<CreateCarBrandRequest>();

            for (int i = 0; i < carBrandArray.Length; i++)
            {
                CreateCarBrandRequest createCarBrandRequest = new CreateCarBrandRequest();

                createCarBrandRequest.BrandName = carBrandArray[i];

                myList.Add(createCarBrandRequest);
            }

            return myList;
        }


        public IEnumerable<CarBrandDto> DisplayBranchData()
        {

            var myList = new List<CarBrandDto>();

            for (int i = 0; i < carBrandArray.Length; i++)
            {
                CarBrandDto carBrandDto = new CarBrandDto();

                carBrandDto.Name = carBrandArray[i];

                myList.Add(carBrandDto);
            }

            return myList;
        }


    }


}
