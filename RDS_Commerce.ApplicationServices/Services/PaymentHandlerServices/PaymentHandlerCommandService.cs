using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHandlerRequest;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Services.PaymentHandlerServices;
public sealed class PaymentHandlerCommandService : BaseService<PaymentHandler>, IPaymentHandlerCommandService
{
    private readonly IPaymentHandlerRepository _paymentHandlerRepository;


    public PaymentHandlerCommandService(INotificationHandler notification, 
                                        IValidate<PaymentHandler> validate,
                                        IPaymentHandlerRepository paymentHandlerRepository) 
        : base(notification, validate)
    {
        _paymentHandlerRepository = paymentHandlerRepository;
    }

    public void Dispose() => _paymentHandlerRepository.Dispose();

    public async Task<bool> CreatePaymentHandlerAsync(PaymentHandlerDtoForRegister paymentHandlerDtoForRegister)
    {
        var paymnetHanlder = paymentHandlerDtoForRegister.MapTo<PaymentHandlerDtoForRegister, PaymentHandler>();

        if (!await EntityValidationAsync(paymnetHanlder)) return false;

        return await _paymentHandlerRepository.SaveAsync(paymnetHanlder);
    }

    public async Task<bool> UpdatePaymentHandlerAsync(PaymentHandlerDtoForUpdate paymentHandlerDtoForUpdate)
    {
        var paymnetHanlder = await _paymentHandlerRepository.FindByPredicateAsync(ph => ph.PaymentHanlderId == paymentHandlerDtoForUpdate.PaymentHanlderId, false);

        if (paymnetHanlder is null)
            return _notification.CreateNotification("Configurações para pagamentos", EMessage.NotFound.GetDescription().FormatTo("Configurações para pagamentos"));

        SetUpdatePaymentHandler(paymnetHanlder, paymentHandlerDtoForUpdate);

        if (!await EntityValidationAsync(paymnetHanlder)) return false;

        return await _paymentHandlerRepository.UpdateAsync(paymnetHanlder);
    }

    private static void SetUpdatePaymentHandler(PaymentHandler paymentHandler, PaymentHandlerDtoForUpdate paymentHandlerDtoForUpdate)
    {
        paymentHandler.PaymentDescription = paymentHandlerDtoForUpdate.PaymentDescription;
        paymentHandler.PixKey = paymentHandlerDtoForUpdate.PixKey;
        paymentHandler.Discount = paymentHandlerDtoForUpdate.Discount;
    }
}
