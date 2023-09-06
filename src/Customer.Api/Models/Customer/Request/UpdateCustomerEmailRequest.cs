namespace Customer.Api.Models.Customer.Request;

public record UpdateCustomerEmailRequest
{
    public string NewEmail { get; init; }
    public string NewEmailConfirm { get; init; }
}