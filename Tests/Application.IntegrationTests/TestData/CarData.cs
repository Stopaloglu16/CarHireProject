using Application.Aggregates.CarAggregate.Commands.Create;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{

    public class CarData
    {

        private readonly List<CreateCarRequest> cars;
        private readonly List<string> carNumberPlates;
        private readonly CreateCarRequest createCarRequest;

        public CarData(bool withbranch = true)
        {

            var rand = new Random();
            cars = new List<CreateCarRequest>();
            carNumberPlates = new List<string>();


            for (int i = 0; i < 10; i++)
            {
                cars.Add(new CreateCarRequest(CreatenumberPlate(),
                                                         withbranch == true ? rand.Next(1, 10) : null,
                                                         rand.Next(1, 7), //Carmodel
                                                         rand.Next(0, 1),
                                                         rand.Next(100, 10000),
                                                         rand.Next(8, 15)));
            }

        }


        public string CreatenumberPlate()
        {
            var rand = new Random();
            string newPlate = "";

            while (true)
            {
                newPlate = String.Concat("AA", rand.Next(10, 99), (char)rand.Next('A', 'Z'));

                if (!carNumberPlates.Contains(newPlate)) break;

            }

            return newPlate;
        }


        public IEnumerable<CreateCarRequest> CreateCarDataList()
        {

            return cars;
        }


        public IEnumerable<CreateCarRequest> DisplayCarModelData()
        {

            return cars;
        }


        public CreateCarRequest CreateOneCarNoBranch()
        {
            return new CreateCarRequest("Test01",
                                                        null,
                                                        1,
                                                        0,
                                                        100,
                                                        8);
        }

    }

}
