namespace Customer.Api.Models.Customer.Request;

public record UpdateCustomerPasswordRequest
{
    public string Password { get; init; }
    public string NewPassword { get; init; }
    public string NewPasswordConfirm { get; init; }
}