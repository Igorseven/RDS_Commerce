using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.AsaasIntegrationRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;
using RDS_Commerce.ApplicationServices.Handlers.Builders.CreditCard;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services.PaymentServices;
public sealed class PaymentCommandService : IPaymentCommandService
{
    private readonly IAsaasIntegrationCommandService _asaasIntegrationCommandService;
    private readonly INotificationHandler _notification;
    private readonly IClientQueryService _clientQueryService;
    private readonly IPurchaseOrderQueryService _orderQueryService;
    private readonly IPaymentHandlerQueryService _paymentHandlerQueryService;

    public PaymentCommandService(IAsaasIntegrationCommandService asaasIntegrationCommandService,
                          INotificationHandler notification,
                          IClientQueryService clientQueryService,
                          IPurchaseOrderQueryService orderQueryService,
                          IPaymentHandlerQueryService paymentHandlerQueryService)
    {
        _asaasIntegrationCommandService = asaasIntegrationCommandService;
        _notification = notification;
        _clientQueryService = clientQueryService;
        _orderQueryService = orderQueryService;
        _paymentHandlerQueryService = paymentHandlerQueryService;
    }

    public async Task<bool> CardPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment)
    {

        return orderDtoForExecutePayment.PaymentType switch
        {
            ECardType.CREDIT_CARD => await CreditCardPaymentAsync(orderDtoForExecutePayment),
            ECardType.DEBIT_CARD => await DebitCardPaymentAsync(orderDtoForExecutePayment),
            _ => _notification.CreateNotification("Tipo de pagamento", EMessage.NotFound.GetDescription().FormatTo("Formato"))
        };
    }

    private async Task<bool> CreditCardPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment)
    {
        const string ORDER_DESCRIPTION = "Pedido de compra ID:";

        var order = await _orderQueryService.FindByDomainObjectAsync(o => o.Id == orderDtoForExecutePayment.OrderId);
        var client = await _clientQueryService.FindByDomainObjectAsync(c => c.UserId == orderDtoForExecutePayment.UserId,
                                                                       i => i.Include(c => c.AccountIdentity)
                                                                       .Include(c => c.ShippingAddresses)!, true);

        if (client is null) _notification.CreateNotification("Cliente", EMessage.NotFound.GetDescription().FormatTo("Cliente"));

        var createNewPayment = new BillingPaymentRequest
        {
            ClientId = client!.UserId,
            PaymentRequest = new PaymentRequest
            {
                Customer = client.CustomerId!,
                BillingType = orderDtoForExecutePayment.PaymentType.GetDescription(),
                CreditCard = orderDtoForExecutePayment.CreditCardSaveRequest!.MapTo<CreditCardSaveRequest, CreditCardRequest>(),
                CreditCardHolderInfo = CreateCreditCardHolderInfoRequest(client, orderDtoForExecutePayment),
                Value = order!.Amount,
                InstallmentCount = orderDtoForExecutePayment.NumberOfInstallment,
                InstallmentValue = order.Amount.CreateValueOfInstallment(orderDtoForExecutePayment.NumberOfInstallment),
                Description = $"{ORDER_DESCRIPTION} {order.Id}",
                ExternalReference = order.Id.ToString(),
                DueDate = DateTime.UtcNow.AddHours(-3).ToString("yyyy/MM/dd"),
                SplitRequests = new List<SplitRequest>()
            }
        };


        var paymentResponse = await _asaasIntegrationCommandService.CreateCardPurchaseAsync(createNewPayment);

        if (paymentResponse) return true;

        return _notification.CreateNotification("Pagamento", "Ocorreu algum problema ao tentar efetuar a compra.");
    }

    private async Task<bool> DebitCardPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment)
    {
        const string ORDER_DESCRIPTION = "Pedido de compra ID:";

        var order = await _orderQueryService.FindByDomainObjectAsync(o => o.Id == orderDtoForExecutePayment.OrderId);
        var client = await _clientQueryService.FindByDomainObjectAsync(c => c.UserId == orderDtoForExecutePayment.UserId,
                                                                       i => i.Include(c => c.AccountIdentity)
                                                                       .Include(c => c.ShippingAddresses)!, true);

        if (client is null) _notification.CreateNotification("Cliente", EMessage.NotFound.GetDescription().FormatTo("Cliente"));

        var createNewPayment = new BillingPaymentRequest
        {
            ClientId = client!.UserId,
            PaymentRequest = new PaymentRequest
            {
                Customer = client.CustomerId!,
                BillingType = orderDtoForExecutePayment.PaymentType.GetDescription(),
                CreditCard = orderDtoForExecutePayment.CreditCardSaveRequest!.MapTo<CreditCardSaveRequest, CreditCardRequest>(),
                CreditCardHolderInfo = CreateCreditCardHolderInfoRequest(client, orderDtoForExecutePayment),
                Value = order!.Amount,
                InstallmentCount = null,
                InstallmentValue = null,
                Description = $"{ORDER_DESCRIPTION} {order.Id}",
                ExternalReference = order.Id.ToString(),
                DueDate = DateTime.UtcNow.AddHours(-3).ToString("yyyy/MM/dd"),
                SplitRequests = new List<SplitRequest>()
            }
        };


        var paymentResponse = await _asaasIntegrationCommandService.CreateCardPurchaseAsync(createNewPayment);

        if (paymentResponse) return true;

        return _notification.CreateNotification("Pagamento", "Ocorreu algum problema ao tentar efetuar a compra.");
    }

    private static CreditCardHolderInfoRequest CreateCreditCardHolderInfoRequest(Client client, OrderForExecutePayment orderDtoForExecutePayment)
    {
        return CreditCardHolderInfoBuilder.NewObject()
                                          .WithName(orderDtoForExecutePayment.CreditCardSaveRequest.HolderName)
                                          .WithCpfCnpj(client.DocumentNumber)
                                          .WithMobilePhone(client.AccountIdentity.PhoneNumber!)
                                          .WithPhone(client.AccountIdentity.PhoneNumber!)
                                          .WithEmail(client.AccountIdentity.UserName!)
                                          .WithAddressNumber(client.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.Number)
                                          .WithPostalCode(client.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.ZipCode)
                                          .WithAddressComplement(client.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.Complement!)
                                          .DomainRequest();
    }



    public async Task<PixKeyPaymentResponse?> PaymentPixAsync(PixPayment pixPayment)
    {
        const int FIVE_MINUTES_INTO_SECONDS = 300;
        const string FORMT_GENERATE_KEY = "ALL";

        var order = await _orderQueryService.FindByDomainObjectAsync(o => o.Id == pixPayment.OrderId);

        if (order is null)
        {
            _notification.CreateNotification("Pedido", EMessage.NotFound.GetDescription().FormatTo("Pedido"));

            return null;
        }

        var paymentHandler = await _paymentHandlerQueryService.FindByDomainObjectAsync(true);

        var pixRequest = new PixKeyPaymentRequest
        {
            AddressKey = paymentHandler!.PixKey,
            Description = $"{paymentHandler.PaymentDescription} {order.Id}",
            ExpirationDate = DateTime.UtcNow.AddHours(-3),
            ExpirationSeconds = FIVE_MINUTES_INTO_SECONDS,
            Format = FORMT_GENERATE_KEY,
            Value = order.Amount.ToString()
        };

        return await _asaasIntegrationCommandService.CreatePaymentWithPixAsync(pixRequest);
    }
}
