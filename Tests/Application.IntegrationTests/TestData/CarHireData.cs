using Application.Aggregates.CarHireAggregate.Commands.Create;
using System;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{
    public class CarHireData
    {



        public IEnumerable<CreateCarHireCommand> CreateCarHireListData(int carHireListCount)
        {

            var myList = new List<CreateCarHireCommand>();

            for (int i = 1; i < carHireListCount + 1; i++)
            {
                myList.Add(new CreateCarHireCommand(i,
                                                         1,
                                                        1,
                                                        DateTime.Now.AddDays(1),
                                                        DateTime.Now.AddDays(1),
                                                        1,
                                                        DateTime.Now.AddDays(2),
                                                        DateTime.Now.AddDays(2),
                                                        120,
                                                        15));
            }

            return myList;
        }



        public IEnumerable<CreateCarHireCommand> CreateCarHireRejectData()
        {

            var myList = new List<CreateCarHireCommand>();

            myList.Add(new CreateCarHireCommand(1,
                                                     1,
                                                    1,
                                                    DateTime.Now.AddDays(1),
                                                    DateTime.Now.AddDays(1),
                                                    1,
                                                    DateTime.Now.AddDays(3),
                                                    DateTime.Now.AddDays(3),
                                                    0,
                                                    15));


            myList.Add(new CreateCarHireCommand(1,
                                                     2,
                                                    1,
                                                    DateTime.Now.AddDays(5),
                                                    DateTime.Now.AddDays(5),
                                                    1,
                                                    DateTime.Now.AddDays(8),
                                                    DateTime.Now.AddDays(8),
                                                    0,
                                                    15));

            myList.Add(new CreateCarHireCommand(1,
                                                   3,
                                                  1,
                                                  DateTime.Now.AddDays(4),
                                                  DateTime.Now.AddDays(4),
                                                  1,
                                                  DateTime.Now.AddDays(7),
                                                  DateTime.Now.AddDays(7),
                                                  0,
                                                  15));

            myList.Add(new CreateCarHireCommand(1,
                                               3,
                                              1,
                                              DateTime.Now.AddDays(9),
                                              DateTime.Now.AddDays(9),
                                              1,
                                              DateTime.Now.AddDays(12),
                                              DateTime.Now.AddDays(12),
                                              0,
                                              15));


            return myList;
        }



    }

}
