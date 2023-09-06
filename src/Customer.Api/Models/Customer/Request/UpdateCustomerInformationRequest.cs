namespace Customer.Api.Models.Customer.Request;

public record UpdateCustomerInformationRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}