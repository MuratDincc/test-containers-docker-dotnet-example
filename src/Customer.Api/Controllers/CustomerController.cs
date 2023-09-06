using Customer.Api.Business.Customer.Abstracts;
using Customer.Api.Models.Customer.Request;
using Customer.Api.Models.Customer.Response;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;

[ApiController]
[Route("api/v1/customers")]
public class CustomerController : ControllerBase
{
    #region Fields

    private readonly ICustomerBusiness _customerBusiness;

    #endregion

    #region Ctor

    public CustomerController(ICustomerBusiness customerBusiness)
    {
        _customerBusiness = customerBusiness;
    }

    #endregion

    #region Methods

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerRequest request)
    {
        return Ok(await _customerBusiness.Create(new Business.Customer.Dto.CreateCustomerDto
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _customerBusiness.GetById(id));
    }

    [HttpPatch("{id}/information")]
    public async Task<IActionResult> UpdateInformation([FromRoute] int id, [FromBody] UpdateCustomerInformationRequest request)
    {
        return Ok(await _customerBusiness.UpdateInformation(new Business.Customer.Dto.UpdateCustomerInformationDto
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName
        }));
    }

    [HttpPatch("{id}/email-change")]
    public async Task<IActionResult> UpdateEmail([FromRoute] int id, [FromBody] UpdateCustomerEmailRequest request)
    {
        return Ok(await _customerBusiness.UpdateEmail(new Business.Customer.Dto.UpdateCustomerEmailDto
        {
            Id = id,
            NewEmail = request.NewEmail,
            NewEmailConfirm = request.NewEmailConfirm
        }));
    }

    [HttpPatch("{id}/password-change")]
    public async Task<IActionResult> UpdatePassword([FromRoute] int id, [FromBody] UpdateCustomerPasswordRequest request)
    {
        return Ok(await _customerBusiness.UpdatePassword(new Business.Customer.Dto.UpdateCustomerPasswordDto
        {
            Id = id,
            Password = request.Password,
            NewPassword = request.NewPassword,
            NewPasswordConfirm = request.NewPasswordConfirm
        }));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCustomerRequest request)
    {
        var response = await _customerBusiness.Login(new Business.Customer.Dto.LoginCustomerDto
        {
            Email = request.Email,
            Password = request.Password
        });

        if (response != null)
        {
            return Ok(new LoginCustomerResponse
            {
                Id = response.Id,
                Email = response.Email,
                TokenExpiry = response.TokenExpiry
            });
        }
        else
        {
            return BadRequest();
        }
    }

    #endregion
}