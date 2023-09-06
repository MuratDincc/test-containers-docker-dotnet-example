namespace Customer.Api.Business.Customer.Dto;

public record LoginCustomerResultDto
{
    public int Id { get; init; }
    public string Email { get; init; }
    public DateTime TokenExpiry { get; init; }
}