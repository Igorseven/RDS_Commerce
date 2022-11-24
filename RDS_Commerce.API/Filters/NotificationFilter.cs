using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RDS_Commerce.API.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.API.Filters;

public sealed class NotificationFilter : ActionFilterAttribute
{
    private readonly INotificationHandler _notification;

	public NotificationFilter(INotificationHandler notification)
	{
		_notification = notification;
	}

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!ExternalMethodExtension.IsMethodGet(context) && _notification.HasNotification())
            context.Result = new BadRequestObjectResult(_notification.GetNotifications());

        base.OnActionExecuted(context);
    }
}
