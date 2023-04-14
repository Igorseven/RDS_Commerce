using Microsoft.EntityFrameworkCore;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
using RDS_Commerce.ApplicationServices.Handlers.Builders.CreditCard;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Handlers.Factories.Payment;
public sealed class PaymentFactory : IPaymentFactory
{
    private readonly IBillingCommandService _billingService;
    private readonly INotificationHandler _notification;
    private readonly IClientQueryService _clientQueryService;
    private readonly IPurchaseOrderQueryService _orderQueryService;

    public PaymentFactory(IBillingCommandService billingService, 
                          INotificationHandler notification,
                          IClientQueryService clientQueryService,
                          IPurchaseOrderQueryService orderQueryService)
    {
        _billingService = billingService;
        _notification = notification;
        _clientQueryService = clientQueryService;
        _orderQueryService = orderQueryService;
    }

    public async Task<bool> CreateNewPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment)
    {

        return orderDtoForExecutePayment.PaymentType switch
        {
            EBillingType.CREDIT_CARD => await PaymentCreditCardAsync(orderDtoForExecutePayment),
            _ => _notification.CreateNotification("Tipo de pagamento", EMessage.NotFound.GetDescription().FormatTo("Formato"))
        };
    }

    private async Task<bool> PaymentCreditCardAsync(OrderForExecutePayment orderDtoForExecutePayment)
    {
        var paymentResponse = await _billingService.CreateCreditPurchaseAsync(await CreatePaymentRequest(orderDtoForExecutePayment));

        if (paymentResponse) return true;

        return _notification.CreateNotification("Pagamento", "Ocorreu algum problema ao tentar efetuar a compra.");
    }


    private async Task<BillingPaymentRequest> CreatePaymentRequest(OrderForExecutePayment orderDtoForExecutePayment)
    {
        const string ORDER_DESCRIPTION = "Vendas";

        var order = await _orderQueryService.FindByDomainObjectAsync(o => o.Id == orderDtoForExecutePayment.OrderId);
        var client = await _clientQueryService.FindByDomainObjectAsync(c => c.UserId == orderDtoForExecutePayment.UserId, 
                                                                       i => i.Include(c => c.AccountIdentity)
                                                                       .Include(c => c.ShippingAddresses)!, true);

        if (client is null) _notification.CreateNotification("Cliente", EMessage.NotFound.GetDescription().FormatTo("Cliente"));

        return new BillingPaymentRequest
        {
            ClientId = client!.UserId,
            PaymentRequest = new PaymentRequest
            {
                Customer = client.CustomerId!,
                BillingType = orderDtoForExecutePayment.PaymentType.GetDescription(),
                CreditCard = orderDtoForExecutePayment.CreditCardSaveRequest.MapTo<CreditCardSaveRequest, CreditCardRequest>(),
                CreditCardHolderInfo = CreateCreditCardHolderInfoRequest(client, orderDtoForExecutePayment),
                Value = order!.Amount,
                InstallmentCount = orderDtoForExecutePayment.NumberOfInstallment,
                InstallmentValue = order.Amount / orderDtoForExecutePayment.NumberOfInstallment,
                Description = ORDER_DESCRIPTION,
                ExternalReference = ORDER_DESCRIPTION,
                DueDate = DateTime.UtcNow.AddHours(-3).ToString("yyyy/MM/dd"),
                SplitRequests = new List<SplitRequest>()
            }
        };
    }


    private CreditCardHolderInfoRequest CreateCreditCardHolderInfoRequest(Client client, OrderForExecutePayment orderDtoForExecutePayment)
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
}
