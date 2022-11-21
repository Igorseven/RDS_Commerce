using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.Business.Handler.NotificationSettings;
public sealed class NotificationHandler : INotificationHandler
{
    private List<DomainNotification> _notifications;

    public NotificationHandler()
    {
        _notifications= new List<DomainNotification>();
    }

    public List<DomainNotification> GetNotifications() => _notifications;

    public bool HasNotification() => _notifications.Any();

    public bool CreateNotification(string key, string value)
    {
        _notifications.Add(new DomainNotification(key, value));

        return false;
    }

    public void CreateNotification(DomainNotification notification)
    {
        _notifications.Add(notification);
    }

    public void CreateNotifications(IEnumerable<DomainNotification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public void CreateNotifications(Dictionary<string, string> notifications)
    {
        foreach (var notification in _notifications)
        {
            CreateNotification(notification);
        }
    }
}
