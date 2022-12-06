using RDS_Commerce.Business.Handler.NotificationSettings;

namespace RDS_Commerce.UnitTest.Handlers;
public sealed class NotificationHandlerUnitTest
{
    private readonly NotificationHandler _notificationHandler;

	public NotificationHandlerUnitTest()
	{
        _notificationHandler = new();
    }

    [Fact]
    [Trait("Sucess", "Create new notification")]
    public void CreateNotification_HasNotificationAndReturnFalse()
    {
        const string KEY_NOTIFICATION = "Not Found";
        const string VALUE_NOTIFICATION = "Objeto não encontrado.";

        var result = _notificationHandler.CreateNotification(KEY_NOTIFICATION, VALUE_NOTIFICATION);

        Assert.True(_notificationHandler.HasNotification());
        Assert.False(result);
    }

    [Fact]
    [Trait("Sucess", "Create new notification")]
    public void CreateNotification_HasNotificationIsTrue()
    {
        string KEY_NOTIFICATION = "Not Found";
        string VALUE_NOTIFICATION = "Objeto não encontrado.";

        _notificationHandler.CreateNotification(new DomainNotification(KEY_NOTIFICATION, VALUE_NOTIFICATION));

        Assert.True(_notificationHandler.HasNotification());
    }

    [Fact]
    [Trait("Sucess", "Create new notification")]
    public void CreateNotifications_HasNotificationIsTrue()
    {
        string VALUE_NOTIFICATION = "Objeto não encontrado.";

        var notifications = new Dictionary<string, string>
        {
            { "notification One", VALUE_NOTIFICATION },
            { "notification Two", VALUE_NOTIFICATION },
            { "notification Three", VALUE_NOTIFICATION }
        };

        var notificationsList = DomainNotification.Create(notifications);

        _notificationHandler.CreateNotifications(notificationsList);

        Assert.True(_notificationHandler.HasNotification());
        Assert.True(_notificationHandler.GetNotifications().Count == 3);
    }
}
