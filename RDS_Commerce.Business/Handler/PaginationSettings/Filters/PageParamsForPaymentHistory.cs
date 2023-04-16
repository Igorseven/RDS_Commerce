using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Business.Handler.PaginationSettings.Filters;
public sealed class PageParamsForPaymentHistory : PageParams
{
    public EBillingType? PaymentType { get; set; }
    public string? PaymentDescription { get; set; }
    public int? InstallmentNumber { get; set; }
    public decimal? PyamentValue { get; set; }
    public DateTime? PaymentDate { get; set; }
}
