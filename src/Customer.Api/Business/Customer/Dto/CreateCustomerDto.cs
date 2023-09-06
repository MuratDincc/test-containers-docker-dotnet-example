namespace Customer.Api.Business.Customer.Dto;

public record CreateCustomerDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}