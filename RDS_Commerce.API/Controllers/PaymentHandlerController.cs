using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHandlerRequest;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PaymentHandlerController : ControllerBase
{
    private readonly IPaymentHandlerCommandService _paymentHandlerCommandService;

    public PaymentHandlerController(IPaymentHandlerCommandService paymentHandlerCommandService)
    {
        _paymentHandlerCommandService = paymentHandlerCommandService;
    }

    [HttpPost("payment_handler_register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> RegisterPaymentHandlerAsync(PaymentHandlerDtoForRegister paymentHandlerDtoForRegister) => 
        await _paymentHandlerCommandService.CreatePaymentHandlerAsync(paymentHandlerDtoForRegister);
}
