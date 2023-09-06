using Customer.Api.Business.Customer.Dto;

namespace Customer.Api.Business.Customer.Abstracts;

public interface ICustomerBusiness
{
    Task<int> Create(CreateCustomerDto request);

    Task<int> UpdateInformation(UpdateCustomerInformationDto request);
    Task<int> UpdateEmail(UpdateCustomerEmailDto request);
    Task<int> UpdatePassword(UpdateCustomerPasswordDto request);

    Task<GetCustomerDto> GetById(int id);

    Task<LoginCustomerResultDto> Login(LoginCustomerDto request);
}