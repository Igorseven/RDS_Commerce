namespace RDS_Commerce.Business.Handler.NotificationSettings;
public sealed class DomainNotification
{
    public string Key { get; set; }
    public string Value { get; set; }

    public DomainNotification(string key, string value) => 
        (Key, Value) = (key, value);


    public static IEnumerable<DomainNotification> Create(Dictionary<string, string> notifications)
    {
        foreach (var notification in notifications)
        {
            yield return new DomainNotification(notification.Key, notification.Value);
        }
    }
}
