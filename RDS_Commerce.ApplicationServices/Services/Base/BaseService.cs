using RDS_Commerce.Business.Handler.NotificationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.ApplicationServices.Services.Base;
public abstract class BaseService<T> where T : class
{
    protected readonly INotificationHandler _notification;
    protected readonly IValidate<T> _validate;

    protected BaseService(INotificationHandler notification, IValidate<T> validate)
    {
        _notification = notification;
        _validate = validate;
    }

    protected async Task<bool> EntityValidationAsync(T entity)
    {
        if (_validate is null)
            return _notification.CreateNotification("Válidação de objeto", "Objeto inválido");

        var validationResponse = await _validate.ValidationAsync(entity);

        if (!validationResponse.Valid)
            _notification.CreateNotifications(DomainNotification.Create(validationResponse.Errors));

        return validationResponse.Valid;
    }
}
