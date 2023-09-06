namespace Customer.Api.Business.Customer.Dto;

public record UpdateCustomerInformationDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}