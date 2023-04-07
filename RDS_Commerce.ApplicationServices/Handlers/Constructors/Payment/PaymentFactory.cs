using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderRequest;
using RDS_Commerce.ApplicationServices.Handlers.Builders.CreditCard;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Handler.NotificationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Handlers.Factories.Payment;
public sealed class PaymentFactory : IPaymentFactory
{
    private readonly IBillingCommandService _billingService;
    private readonly INotificationHandler _notification;
    private readonly IClientQueryService _clientQueryService;

    public PaymentFactory(IBillingCommandService billingService, 
                          INotificationHandler notification,
                          IClientQueryService clientQueryService)
    {
        _billingService = billingService;
        _notification = notification;
        _clientQueryService = clientQueryService;
    }

    public async Task<bool> CreateNewPaymentAsync(OrderDtoForExecutePayment orderDtoForExecutePayment)
    {

        return orderDtoForExecutePayment.PaymentType switch
        {
            EBillingType.CREDIT_CARD => await PaymentCreditCardAsync(orderDtoForExecutePayment),
            _ => _notification.CreateNotification("Tipo de pagamento", EMessage.NotFound.GetDescription().FormatTo("Formato"))
        };
    }

    private async Task<bool> PaymentCreditCardAsync(OrderDtoForExecutePayment orderDtoForExecutePayment)
    {
        //await _billingService.CreateCreditPurchaseAsync(await CreatePaymentRequest(clientId, clientUserRegister)


        return _notification.CreateNotification("Cartão de crédito", EMessage.NotFound.GetDescription().FormatTo("Compra no cartao de crédito"));
    }


    private async Task<BillingPaymentRequest> CreatePaymentRequest(OrderDtoForExecutePayment orderDtoForExecutePayment)
    {
        const string ORDER_DESCRIPTION = "Vendas";

        var client = await _clientQueryService.FindByDomainObjectAsync(c => c.UserId == orderDtoForExecutePayment.UserId, null, true);
        //var order = await _orderQueryService.FindByDomainObjectAsync(orderDtoForExecutePayment.OrderId);

        return new BillingPaymentRequest
        {
            ClientId = client.UserId,
            PaymentRequest = new PaymentRequest
            {
                Customer = client.CustomerId,
                BillingType = orderDtoForExecutePayment.PaymentType.GetDescription(),
                CreditCard = orderDtoForExecutePayment.CreditCardSaveRequest.MapTo<CreditCardSaveRequest, CreditCardRequest>(),
                CreditCardHolderInfo = CreateCreditCardHolderInfoRequest(client),
                Value = 50.50m, // alterar com o valor total do pedido
                Description = ORDER_DESCRIPTION,
                DueDate = DateTime.Now.ToString("yyyy/MM/dd")
            }
        };
    }


    private CreditCardHolderInfoRequest CreateCreditCardHolderInfoRequest(Client client)
    {
        return CreditCardHolderInfoBuilder.NewObject()
                                          .WithName(client.FullName)
                                          .WithCpfCnpj(client.DocumentNumber)
                                          .WithMobilePhone(client.AccountIdentity.PhoneNumber!)
                                          .WithEmail(client.AccountIdentity.UserName!)
                                          .WithAddressNumber(client.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.Number)
                                          .WithPostalCode(client.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.ZipCode)
                                          .WithAddressComplement(client.ShippingAddresses!.FirstOrDefault(sa => sa.SelectedForShipping)!.Complement!)
                                          .DomainRequest();
    }
}
