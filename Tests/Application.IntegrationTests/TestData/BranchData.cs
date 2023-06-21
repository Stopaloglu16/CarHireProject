using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Queries;
using Domain.Common;
using System.Collections.Generic;

namespace Application.IntegrationTests.TestData
{
    public class BranchData
    {

        private readonly string[] branchNameArray;

        public BranchData()
        {
            branchNameArray = new string[4] { "Derby", "Nottingham", "Sheffield", "Mansfield" };
        }

        public IEnumerable<CreateBranchRequest> CreateBranchData()
        {

            var myList = new List<CreateBranchRequest>();

            for (int i = 0; i < branchNameArray.Length; i++)
            {
                CreateBranchRequest createBranchRequest = new CreateBranchRequest();

                createBranchRequest.BranchName = branchNameArray[i];
                createBranchRequest.Address = new AddressDto() { Address1 = $"{i} street", Postcode = "AB1 2CD", City = branchNameArray[i] };
                createBranchRequest.carChosenValues = new List<ChosenItem>();

                myList.Add(createBranchRequest);
            }

            return myList;
        }


        public CreateBranchRequest CreateSingleBranchData()
        {

            CreateBranchRequest createBranchRequest = new CreateBranchRequest();

            createBranchRequest.BranchName = branchNameArray[0];
            createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = branchNameArray[0] };

            createBranchRequest.carChosenValues = new List<Domain.Common.ChosenItem>();

            return createBranchRequest;
        }


        public CreateBranchRequest CreateBranchDataWithCars()
        {
            CreateBranchRequest createBranchRequest = new CreateBranchRequest();

            createBranchRequest.BranchName = branchNameArray[0];
            createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = branchNameArray[0] };

            createBranchRequest.carChosenValues = new List<Domain.Common.ChosenItem>();
            createBranchRequest.carChosenValues.Add(new ChosenItem() { ChosenId = 1, IsChosen = true });
            createBranchRequest.carChosenValues.Add(new ChosenItem() { ChosenId = 2, IsChosen = false });

            return createBranchRequest;
        }

        public IEnumerable<BranchDto> DisplayBranchData()
        {

            var myList = new List<BranchDto>();

            for (int i = 0; i < branchNameArray.Length; i++)
            {
                BranchDto createBranchRequest = new BranchDto();

                createBranchRequest.Id = i+1;
                createBranchRequest.BranchName = branchNameArray[i];
                createBranchRequest.Address = new AddressDto() { Address1 = "", Postcode = "", City = branchNameArray[i] };

                myList.Add(createBranchRequest);
            }

            return myList;
        }


    }
}
