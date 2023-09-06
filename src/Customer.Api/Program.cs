using Customer.Api.Business.Customer;
using Customer.Api.Business.Customer.Abstracts;
using Customer.Api.Data;
using Customer.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));

builder.Services.AddScoped<ICustomerBusiness, CustomerBusiness>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ApplyMigrations();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }