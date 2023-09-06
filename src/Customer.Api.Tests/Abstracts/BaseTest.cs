using Customer.Api.Business.Customer.Abstracts;
using Customer.Api.Data;
using Customer.Api.Tests.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Api.Tests.Abstracts;

public abstract class BaseTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected readonly ICustomerBusiness _customerBusiness;
    protected readonly CustomerApiContext _dbContext;

    protected BaseTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        _customerBusiness = _scope.ServiceProvider.GetRequiredService<ICustomerBusiness>();
        _dbContext = _scope.ServiceProvider.GetRequiredService<CustomerApiContext>();
    }

    public void Dispose()
    {
        _scope?.Dispose();
        _dbContext?.Dispose();
    }
}