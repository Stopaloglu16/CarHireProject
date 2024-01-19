using Application.Aggregates.AddressAggregate.Queries;
using Application.Aggregates.BranchAggregate.Commands.Create;
using SharedFunctionLibrary;
using System.ComponentModel.DataAnnotations;

namespace Application.UnitTests.Application.Exception.CarrierExceptions
{
    public class BranchExceptionTests
    {
        private CreateBranchRequest? _createBranchRequest;
        private string carrierNameLong = TextGenerator.RandomString(52); //52 char
        private ICollection<ValidationResult>? results = null;

        [Fact]
        public void CreateBranch_NameLimit_Fail()
        {
            _createBranchRequest = new CreateBranchRequest()
            {
                BranchName = carrierNameLong,
                Address = new AddressDto()
                {
                    Address1 = "",
                    City = "Derby",
                    Postcode = "De12 3NS"
                }
            };

            Assert.False(ValidateClass.Validate(_createBranchRequest, out results));

            var resultList = results.ToList();

            Assert.Contains("50", resultList[0].ErrorMessage);
            Assert.Contains("BranchName", resultList[0].ErrorMessage);
        }

    }
}
