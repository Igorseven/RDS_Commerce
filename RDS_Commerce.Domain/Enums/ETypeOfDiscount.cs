using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum ETypeOfDiscount : ushort
{
    [Description("FIXED")]
    Fixed = 1,

    [Description("PERCENTAGE")]
    Percentage
}
