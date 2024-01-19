namespace Domain.Common
{
    public abstract class AuditableEntity<T> : BaseEntity<T>
    {
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
