using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aggregates.BranchAggregate.Commands.Create
{
    public class CreateBranchCarsRequest
    {
        public ICollection<ChosenItem> Cars { get; set; } = new List<ChosenItem>();

    }
}
