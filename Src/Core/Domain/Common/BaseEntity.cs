using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    // Using non-generic integer types for simplicity and to ease caching logic
    public abstract class BaseEntity<T> 
    {

        [Key]
        [Required]
        public T Id { get; set; }

        public byte IsDeleted { get; set; } = 0;
    }
}
