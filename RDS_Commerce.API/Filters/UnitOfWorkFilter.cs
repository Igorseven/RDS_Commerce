using Microsoft.AspNetCore.Mvc.Filters;
using RDS_Commerce.API.Extensions;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.API.Filters;

public sealed class UnitOfWorkFilter : ActionFilterAttribute
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationHandler _notification;

    public UnitOfWorkFilter(IUnitOfWork unitOfWork, INotificationHandler notification)
    {
        _unitOfWork = unitOfWork;
        _notification = notification;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (ExternalMethodExtension.IsMethodGet(context))
            return;

        if (context.Exception is null && context.ModelState.IsValid && !_notification.HasNotification())
            _unitOfWork.CommitTransaction();
        else
            _unitOfWork.RolbackTransaction();

        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (ExternalMethodExtension.IsMethodGet(context))
            return;

        _unitOfWork.BeginTransaction();

        base.OnActionExecuting(context);
    }
}
