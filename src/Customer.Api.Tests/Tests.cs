using Customer.Api.Business.Customer.Dto;
using Customer.Api.Tests.Abstracts;
using Customer.Api.Tests.Factory;

namespace Application.IntegrationTests;

public class Tests : BaseTest
{
    #region Ctor

    public Tests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    #endregion

    #region Methods

    public async Task<int> Business_Create_Customer()
    {
        var model = new CreateCustomerDto
        {
            FirstName = "Murat",
            LastName = "Dinç",
            Email = "test@muratdinc.dev",
            Password = "123123"
        };

        return await _customerBusiness.Create(model);
    }

    #endregion

    #region Tests

    #region Create Customer

    [Trait("Create", "Integration tests for Create Customer")]
    [Fact(DisplayName = "Create customer business")]
    public async Task Create_Customer()
    {
        var customerId = await Business_Create_Customer();
        var result = _customerBusiness.GetById(customerId);

        Assert.NotNull(result);
    }

    [Trait("Create", "Integration tests for Create Customer")]
    [Fact(DisplayName = "Create customer email control")]
    public async Task Create_Customer_Email_Control()
    {
        var customerId = await Business_Create_Customer();

        Task Action() => Business_Create_Customer();

        await Assert.ThrowsAsync<Exception>(Action);
    }

    #endregion

    #region Login

    [Trait("Login", "Integration tests for Login Customer")]
    [Fact(DisplayName = "Login customer business")]
    public async Task Login_Customer()
    {
        await Business_Create_Customer();

        var model = new LoginCustomerDto
        {
            Email = "test@muratdinc.dev",
            Password = "123123"
        };

        var result = await _customerBusiness.Login(model);

        Assert.NotNull(result);
    }

    #endregion

    #region Update

    [Trait("Update", "Integration tests for Updates")]
    [Fact(DisplayName = "Update information")]
    public async Task Update_Customer_Information()
    {
        var result = await _customerBusiness.UpdateInformation(new UpdateCustomerInformationDto
        {
            Id = 1,
            FirstName = "Muratt",
            LastName = "Dinçç"
        });

        Assert.True(result > 0);
    }

    [Trait("Update", "Integration tests for Updates")]
    [Fact(DisplayName = "Update password")]
    public async Task Update_Customer_Password()
    {
        var customerId = await Business_Create_Customer();

        var result = await _customerBusiness.UpdatePassword(new UpdateCustomerPasswordDto
        {
            Id = customerId,
            Password = "123123",
            NewPassword = "123123!!",
            NewPasswordConfirm = "123123!!"
        });

        Assert.True(result > 0);
    }

    [Trait("Update", "Integration tests for Updates")]
    [Fact(DisplayName = "Update password new password control")]
    public async Task Update_Customer_Password_New_Password_Control()
    {
        Task Action() => _customerBusiness.UpdatePassword(new UpdateCustomerPasswordDto
        {
            Id = 1,
            Password = "123123",
            NewPassword = "Murat!!",
            NewPasswordConfirm = "123123!!"
        });

        await Assert.ThrowsAsync<Exception>(Action);
    }

    #endregion

    #endregion
}