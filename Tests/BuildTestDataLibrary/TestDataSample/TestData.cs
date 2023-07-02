using System.Collections;

namespace BuildTestDataLibrary.TestDataSample
{

    public class MyEntityListGenerator
    {
        public static IEnumerable<MyEntity> Creates =>
            new List<MyEntity>
            {
                new MyEntity { Input = 1, Expected = "One" },
                new MyEntity { Input = 2, Expected = "Two" },
                new MyEntity { Input = 3, Expected = "Three" },
                new MyEntity { Input = 4, Expected = "Four" },
                new MyEntity { Input = 5, Expected = "Five" }
            };
    }

    public class MyEntityGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (MyEntity data in MyEntityListGenerator.Creates)
                yield return new object[] { data };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MyEntityRequestGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (MyEntity data in MyEntityListGenerator.Creates)
                yield return new object[] { new CreateMyEntityRequest(data.Input, data.Expected) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }



    public class MyEntity
    {
        public int Input { get; set; }
        public string Expected { get; set; }
    }


    public class CreateMyEntityRequest
    {
        public CreateMyEntityRequest(int input, string expected)
        {
            Input = input;
            Expected = expected;
        }

        public int Input { get; set; }
        public string Expected { get; set; }
    }
}
