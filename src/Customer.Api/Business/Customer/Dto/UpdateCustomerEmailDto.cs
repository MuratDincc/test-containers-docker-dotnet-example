namespace Customer.Api.Business.Customer.Dto;

public record UpdateCustomerEmailDto
{
    public int Id { get; init; }
    public string NewEmail { get; init; }
    public string NewEmailConfirm { get; init; }
}