namespace Customer.Api.Models.Customer.Response;

public record LoginCustomerResponse
{
    public int Id { get; init; }
    public string Email { get; init; }
    public DateTime TokenExpiry { get; init; }
}