namespace Customer.Api.Entities;

public abstract class BaseAuditableEntity : BaseEntity
{
    public bool Deleted { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }
}
