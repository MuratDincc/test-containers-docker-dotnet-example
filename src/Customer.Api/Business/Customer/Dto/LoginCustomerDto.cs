namespace Customer.Api.Business.Customer.Dto;

public record LoginCustomerDto
{
    public string Email { get; init; }
    public string Password { get; init; }
}