using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.Business.Interfaces.OthersContracts;
public interface INotificationHandler
{
    bool CreateNotification(string key, string value);
    void CreateNotification(DomainNotification notification);
    void CreateNotifications(IEnumerable<DomainNotification> notifications);
    bool HasNotification();
    List<DomainNotification> GetNotifications();
}
