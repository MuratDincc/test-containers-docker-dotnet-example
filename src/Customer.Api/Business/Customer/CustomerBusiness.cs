using Customer.Api.Business.Customer.Abstracts;
using Customer.Api.Business.Customer.Dto;
using Customer.Api.Data;
using Customer.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Business.Customer;

public class CustomerBusiness : ICustomerBusiness
{
    #region Fields

    private readonly CustomerApiContext _customerApiContext;

    #endregion

    #region Ctor

    public CustomerBusiness(CustomerApiContext customerApiContext)
    {
        _customerApiContext = customerApiContext;
    }

    #endregion

    #region Methods

    public async Task<int> Create(CreateCustomerDto request)
    {
        var customer = await _customerApiContext.Customer.AsNoTracking().FirstOrDefaultAsync(predicate: x => x.Email == request.Email);
        if (customer != null)
            throw new Exception("Customer registered");

        var entity = new Entities.Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password.ToMD5(),
            CreatedOnUtc = DateTime.UtcNow
        };

        await _customerApiContext.Customer.AddAsync(entity);
        await _customerApiContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateInformation(UpdateCustomerInformationDto request)
    {
        var customer = await _customerApiContext.Customer.FirstOrDefaultAsync(predicate: x => x.Id == request.Id && !x.Deleted);
        if (customer == null)
            throw new Exception("Customer not found!");

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.UpdatedOnUtc = DateTime.UtcNow;

        await _customerApiContext.SaveChangesAsync();

        return customer.Id;
    }

    public async Task<int> UpdatePassword(UpdateCustomerPasswordDto request)
    {
        var customer = await _customerApiContext.Customer.FirstOrDefaultAsync(predicate: x => x.Id == request.Id && !x.Deleted);
        if (customer == null)
            throw new Exception("Customer not found!");

        if (customer.Password != request.Password.ToMD5())
            throw new Exception("Your current password is incorrect!");

        if (request.NewPassword.ToMD5() != request.NewPasswordConfirm.ToMD5())
            throw new Exception("Passwords cannot be matched!");

        customer.Password = request.NewPassword.ToMD5();
        customer.UpdatedOnUtc = DateTime.UtcNow;

        await _customerApiContext.SaveChangesAsync();

        return customer.Id;
    }

    public async Task<int> UpdateEmail(UpdateCustomerEmailDto request)
    {
        var customer = await _customerApiContext.Customer.FirstOrDefaultAsync(predicate: x => x.Id == request.Id && !x.Deleted);
        if (customer == null)
            throw new Exception("Customer not found!");

        var checkEmail = await _customerApiContext.Customer.FirstOrDefaultAsync(predicate: x => x.Email == request.NewEmail);
        if (checkEmail != null)
            throw new Exception("The new email address you entered is being used by another user");

        if (request.NewEmail != request.NewEmailConfirm)
            throw new Exception("Emails cannot be matched!");

        customer.Email = request.NewEmail;
        customer.UpdatedOnUtc = DateTime.UtcNow;

        await _customerApiContext.SaveChangesAsync();

        return customer.Id;
    }

    public async Task<GetCustomerDto> GetById(int id)
    {
        var customer = await _customerApiContext.Customer.AsNoTracking().FirstOrDefaultAsync(predicate: x => x.Id == id && !x.Deleted);
        if (customer == null)
            throw new Exception("Customer not found!");

        return new GetCustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            CreatedOnUtc = customer.CreatedOnUtc
        };
    }

    public async Task<LoginCustomerResultDto> Login(LoginCustomerDto request)
    {
        var customer = await _customerApiContext.Customer.AsNoTracking().FirstOrDefaultAsync(predicate: x => x.Email == request.Email && x.Password == request.Password.ToMD5() && !x.Deleted);
        if (customer == null)
            throw new Exception("Customer not found!");

        return new LoginCustomerResultDto
        {
            Id = customer.Id,
            Email = customer.Email,
            TokenExpiry = DateTime.UtcNow.AddDays(5)
        };
    }

    #endregion
}