namespace Customer.Api.Business.Customer.Dto;

public record UpdateCustomerPasswordDto
{
    public int Id { get; init; }
    public string Password { get; set; }
    public string NewPassword { get; init; }
    public string NewPasswordConfirm { get; init; }
}