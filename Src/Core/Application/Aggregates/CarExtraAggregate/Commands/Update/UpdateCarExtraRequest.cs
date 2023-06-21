using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarExtraAggregate.Commands.Update
{
    public class UpdateCarExtraRequest
    {

        public int Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

    }

}
