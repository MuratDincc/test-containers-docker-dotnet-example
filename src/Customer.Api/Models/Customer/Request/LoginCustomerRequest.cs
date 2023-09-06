namespace Customer.Api.Models.Customer.Request;

public record LoginCustomerRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}