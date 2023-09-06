using System.ComponentModel.DataAnnotations;

namespace Customer.Api.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
